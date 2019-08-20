using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Reference added 
using _3EndTDataLayer;

namespace _3EndTBusinessLayer.BusinessObject
{
    /**
     * The CartItem Class
     * 
     * Basically a structure for holding item data
     */
    [Serializable()]
    public class CartItem : IEquatable<CartItem>
    {
        #region Properties

        public int ProductId { get; set; }
        public int ProductItemId { get; set; }

        // A place to store the quantity in the cart
        // This property has an implicit getter and setter.
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        /// <summary>
        /// Product Item name
        /// </summary>
        //public string ProductType { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice
        {
            get { return UnitPrice * Quantity; }
        }

       
        #endregion

        public CartItem(ProductItemInfo pInfo)
        {
            this.ProductItemId = pInfo.ItemId;
            this.ProductId = pInfo.ProductId;
            this.ProductName = pInfo.ProductName;
            //this.ProductType = pInfo.PrimaryFilterValue;
            this.UnitPrice = (decimal)pInfo.Price;
            this.ImageUrl = ProductManager.GetProductById(this.ProductId).ImageUrl??"/Images/NoImage.jpg";
            
            this.Quantity = 1;            
        }

        /**
         * Equals() - Needed to implement the IEquatable interface
         *    Tests whether or not this item is equal to the parameter
         *    This method is called by the Contains() method in the List class
         *    We used this Contains() method in the ShoppingCart AddItem() method
         */
        public bool Equals(CartItem item)
        {
            return item.ProductItemId == this.ProductItemId;
        }
    }

}
