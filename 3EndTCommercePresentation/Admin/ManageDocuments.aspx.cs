using _3EndTBusinessLayer;
using _3EndTDataLayer;
using _3EndTDataLayer.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3EndTCommercePresentation.admin
{
    public partial class ManageDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;
                LoadDocumentsGrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.Page.Validate();

            if (!this.Page.IsValid)
                return;

            var documentDirectory = !string.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("DocumentDirectory")) ? ConfigurationManager.AppSettings.Get("DocumentDirectory") : "/documents/";
            var doc = new Document();
            doc.Title = txtDocumentName.Text;
            if (fuDocument.HasFile)
            {
                var fileName = Path.GetFileName(fuDocument.FileName);

                var extn = Path.GetExtension(fuDocument.FileName);
                if(!extn.Contains("pdf"))
                {
                    lblError.Visible = true;
                    lblError.Text = "Please upload a pdf file.";
                    return;
                }
                
                var directory = Server.MapPath(documentDirectory);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                var physicalFilePath = string.Format("{0}{1}", directory, fileName);

                doc.FilePath = string.Format("{0}{1}", directory, fileName);
                doc.Key = DocumentManager.GenerateUniqueKey(doc.Title, fileName);
                doc.CreatedDate = DateTime.Now;
                var hostUrl = Request.Url.GetLeftPart(UriPartial.Authority);
                doc.Url = string.Format("{0}{1}{2}", hostUrl, documentDirectory, fileName);
                doc.IsActive = true;
                fuDocument.SaveAs(doc.FilePath);

                var recordInserted = DocumentManager.InsertDocumentRecord(doc);
                if (!recordInserted)
                {
                    lblError.Text = "Document Not Inserted";
                    lblError.Visible = true;
                }
            }
            LoadDocumentsGrid();
        }
        protected void LoadDocumentsGrid()
        {
            var docs = DocumentManager.GetAllDocuments();
            grdDocumentLinks.DataSource = docs;
            grdDocumentLinks.DataBind();
        }
    }
}