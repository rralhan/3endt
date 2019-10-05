using _3EndTBusinessLayer;
using _3EndTBusinessLayer.BusinessObject;
using _3EndTDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using _3EndTDataLayer.domain;

namespace _3EndTCommercePresentation.admin
{
    public partial class ManageProductItemPrice : System.Web.UI.Page
    {
        private static string _product = string.Empty;
        private List<Tuple<TierProduct, TierProductPrice>> _listRegTPP = null;
        private List<Tuple<TierProduct, TierProductPrice>> _listTierTPP = null;
        ManageProductPrice objGetdataforExcle = new ManageProductPrice();
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        OleDbConnection Econ;
        SqlConnection con;
        string constr, Query, sqlconn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTiers();
            }
        }
        private void LoadTiers()
        {
            ddlTiers.DataSource = TierManager.GetTiers();
            ddlTiers.DataTextField = "TierName";
            ddlTiers.DataValueField = "TierId";
            ddlTiers.DataBind();

            ddlTiers.SelectedIndex = 0;
        }
        private void LoadProductItems()
        {
            //For Regular Tier
            _listRegTPP = ProductManager.GetAssociatedProductPricesByTier(1);
            _listTierTPP = ProductManager.GetAssociatedProductPricesByTier(Convert.ToInt16(ddlTiers.SelectedValue));

            lblTierHeader.Text = ddlTiers.SelectedItem.Text + " Tier";

            List<ProductItemInfo> lpii = ProductManager.GetAllProductItemInfo();
            lvProductItems.DataSource = lpii;
            lvProductItems.DataBind();
        }

        protected void ddlTiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //For Regular Tier
            _listRegTPP = ProductManager.GetAssociatedProductPricesByTier(1);
            _listTierTPP = ProductManager.GetAssociatedProductPricesByTier(Convert.ToInt16(ddlTiers.SelectedValue));
            LoadProductItems();
        }


        protected void lvProductItems_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Control cntrl = e.Item.FindControl("lblProduct");
                if (cntrl != null)
                {
                    Label lblproduct = cntrl as Label;
                    HtmlTableRow tr = e.Item.FindControl("rowProduct") as HtmlTableRow;
                    if (lblproduct.Text != _product)
                    {
                        _product = lblproduct.Text;
                        tr.Style.Add("display", "");
                    }
                    else
                        tr.Style.Add("display", "none");
                }
                cntrl = e.Item.FindControl("hdnProductItemId");
                if (cntrl != null)
                {
                    HiddenField hdnproductitemid = cntrl as HiddenField;
                    int productitemid = Convert.ToInt32(hdnproductitemid.Value);
                    TextBox txtTierPrices = e.Item.FindControl("txtTierPrices") as TextBox;
                    if (_listRegTPP != null)
                    {
                        Label lblregtierprices = e.Item.FindControl("lblRegularTierPrices") as Label;
                        decimal regpr = Convert.ToDecimal(_listRegTPP.Where(x => (x.Item1 != null && x.Item1.ProductItemId == productitemid)).Select(x => x.Item2.Price).SingleOrDefault());
                        lblregtierprices.Text = string.Format("$ {0:#,###0.00}", regpr);
                        txtTierPrices.Text = string.Format("{0:#,###0.00}", regpr);
                        if (regpr == -9999)
                        {
                            lblregtierprices.Text = "rfq";
                            txtTierPrices.Text = "rfq";
                        }
                    }

                    if (_listTierTPP != null)
                    {
                        decimal tierpr = Convert.ToDecimal(_listTierTPP.Where(x => (x.Item1 != null && x.Item1.ProductItemId == productitemid)).Select(x => x.Item2.Price).SingleOrDefault());
                        txtTierPrices.Text = string.Format("{0:#,###0.00}", tierpr);
                        if (tierpr == -9999)
                            txtTierPrices.Text = "rfq";
                    }

                }


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal price = 0;
            int productitemid = 0;
            int tierid = Convert.ToInt32(ddlTiers.SelectedValue);
            foreach (ListViewItem lv in lvProductItems.Items)
            {
                Control cntrl = lv.FindControl("txtTierPrices");
                if (cntrl != null)
                {
                    TextBox tb = cntrl as TextBox;
                    if (tb.Text != string.Empty)
                    {
                        if (tb.Text.ToLower().Contains("rfq"))
                            price = -9999;
                        else
                            price = Convert.ToDecimal(tb.Text);
                    }
                    cntrl = lv.FindControl("hdnProductItemId");
                    if (cntrl != null)
                    {
                        HiddenField hdnproductitemid = cntrl as HiddenField;
                        productitemid = Convert.ToInt32(hdnproductitemid.Value);
                    }

                    if (productitemid != 0 && (price > 0 || price == -9999))
                        ProductManager.UpdateTierProductPrices(tierid, productitemid, price);
                }
            }
        }



        protected void dpProductItems_PreRender(object sender, EventArgs e)
        {
            LoadProductItems();
        }

        protected void btn_DownloadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                int TierID = Convert.ToInt32(ddlTiers.SelectedValue.ToString().Trim());
                DataTable DTResult = objGetdataforExcle.GetTierPriceForExcelExport(ConnectionString, TierID);


                //using (var workbook = new XLWorkbook())
                //{
                //    var worksheet = workbook.Worksheets.Add(ddlTiers.SelectedItem.Text.ToString().Trim());
                //    worksheet.Add(DTResult);
                //    workbook.SaveAs(ddlTiers.SelectedItem.Text.ToString().Trim() + "_" + DateTime.Now.Date + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year);
                //}

                ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook();
                wbook.Worksheets.Add(DTResult, ddlTiers.SelectedItem.Text.ToString().Trim());
                // Prepare the response
                HttpResponse httpResponse = Response;
                httpResponse.Clear();
                httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Provide you file name here

                string TempName = ddlTiers.SelectedItem.Text.ToString().Trim() + "_" + DateTime.Now.Date.Day.ToString().Trim() + "_" + DateTime.Now.Month.ToString().Trim() + "_" + DateTime.Now.Year.ToString().Trim();
                string filename = "attachment;filename=\"" + TempName + ".xlsx\"";

                httpResponse.AddHeader("content-disposition", filename);
                //"attachment;filename=\"" + ddlTiers.SelectedItem.Text.ToString().Trim() + "_" + DateTime.Now.Date.ToString().Trim() + "_" + DateTime.Now.Month.ToString().Trim() + "_" + DateTime.Now.Year.ToString().Trim()"+ ".xlsx\"");

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    wbook.SaveAs(memoryStream);
                    memoryStream.WriteTo(httpResponse.OutputStream);
                    memoryStream.Close();
                }

                httpResponse.End();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        protected void btn_SaveAndUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (fu_excel.HasFile)
                {

                    string path = string.Concat(Server.MapPath("~/admin/UploadFile/" + fu_excel.FileName));
                    fu_excel.SaveAs(path);
                    // Connection String to Excel Workbook  
                    int x= objGetdataforExcle.TruncateTemptableforProductPriceViaExcel(ConnectionString);

                    string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [" + ddlTiers.SelectedItem.Text.ToString().Trim() + "$" + "]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        // string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(ConnectionString);
                        bulkInsert.DestinationTableName = "TempTierProductPriceTable";
                        bulkInsert.BatchSize = 500;
                        bulkInsert.BulkCopyTimeout = 10000;
                        bulkInsert.WriteToServer(dr);

                        con.Close();
                        //string CurrentFilePath = Path.GetFullPath(fu_excel.PostedFile.FileName);
                        //InsertExcelRecords(CurrentFilePath);
                    }
                    //SP_UpdateTierProductPriceViaExcel
                    int RecordCount = objGetdataforExcle.UpdateProductPriceViaExcel(ConnectionString, Convert.ToInt32(ddlTiers.SelectedValue.ToString().Trim()));

                    if(RecordCount > 0)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Price updated successfully.');", true);
                       //-- Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alert(" + "Price updated successfully." + ");", true);
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void ExcelConn(string FilePath)
        {

            constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", FilePath);
            Econ = new OleDbConnection(constr);

        }
        private void connection()
        {
            //sqlconn = ConfigurationManager.ConnectionStrings["SqlCom"].ConnectionString;
            con = new SqlConnection(ConnectionString);

        }
        private void InsertExcelRecords(string FilePath)
        {
            ExcelConn(FilePath);

            Query = string.Format("Select * FROM [{0}]", ddlTiers.SelectedItem.Text.ToString().Trim() + "$");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable Exceldt = ds.Tables[0];
            connection();
            //creating object of SqlBulkCopy    
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name    
            objbulk.DestinationTableName = "TempTierProductPriceTable";
            ////Mapping Table column    
            //objbulk.ColumnMappings.Add("Name", "Name");
            //objbulk.ColumnMappings.Add("City", "City");
            //objbulk.ColumnMappings.Add("Address", "Address");
            //objbulk.ColumnMappings.Add("Designation", "Designation");
            //inserting Datatable Records to DataBase    
            con.Open();
            objbulk.WriteToServer(Exceldt);
            objbulk.BatchSize = 500;
            objbulk.BulkCopyTimeout = 10000;
            con.Close();

        }

        //protected void Dummy_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        //ProductPriceManager ObjPPM = new ProductPriceManager();
        //        //string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EndtCommerceEntities"].ConnectionString;
        //        //int TierID = Convert.ToInt32(ddlTiers.SelectedValue.ToString());

        //        //DataTable DT = new DataTable();

        //        //DT = ObjPPM.GetProductPriceForExportIntoExcel(ConnectionString, TierID);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message.ToString());
        //    }
        //}

        //protected void Dummy_Click1(object sender, EventArgs e)
        //{

        //}
    }
}