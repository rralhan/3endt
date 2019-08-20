using _3EndTBusinessLayer.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _3EndTCommercePresentation
{
    public static class Utility
    {
        public static Control FindControlRecursive(Control parent, string id)
        {
            if (parent.ID == id)
                return parent;
            foreach (Control c in parent.Controls)
            {
                Control foundctrl = FindControlRecursive(c, id);
                if (foundctrl != null)
                    return foundctrl;
            }
            return null;
        }

        public static void RemoveFromCache(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }
        public static object GetPropertyValue(this object car, string propertyName)
        {
            return car.GetType().GetProperties()
               .Single(pi => pi.Name == propertyName)
               .GetValue(car, null);
        }

        public static Control GetParent(Type T, Control cntrl)
        {
            Control parentcntrl = null;
            while (true)
            {
                parentcntrl = cntrl.Parent;
                if (parentcntrl.GetType() == T)
                    break;
                else
                    cntrl = parentcntrl;
            }
            return parentcntrl;
        }

        public static void BindDropDowns(List<ProductItemInfo> piList, string dataText, string dataId, DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("Select an option", "0"));
            foreach (ProductItemInfo pii in piList)
            {
                ListItem li = new ListItem(pii.GetPropertyValue(dataText).ToString(), pii.GetPropertyValue(dataId).ToString());
                if (!ddl.Items.Contains(li))
                    ddl.Items.Add(li);
            }
            ddl.SelectedIndex = 0;
        }

        public static void ToDisplayNone(this WebControl cntrl) 
        {
            cntrl.Style.Add("display", "none");
        }
        public static void ToDisplayBlock(this WebControl cntrl)
        {
            cntrl.Style.Add("display", "");
        }
        public static void ToDisplayNone(this HtmlControl cntrl)
        {
            cntrl.Style.Add("display", "none");
        }
        public static void ToDisplayBlock(this HtmlControl cntrl)
        {
            cntrl.Style.Add("display", "");
        }
    }
}