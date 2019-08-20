using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using _3EndTDataLayer;

namespace _3EndTBusinessLayer.BusinessObject
{
    [Serializable()]
    public class ShoppingCart
    {
        private ShoppingCart()
        { }
                
        private static readonly ShoppingCart _instance = new ShoppingCart();

        private List<CartItem> _cartItems;
        public List<CartItem> CartItems
        {
            get
            {
                if ((HttpContext.Current.Session["_cartItems" + SessionManager.UserName] == null) || (_cartItems == null))
                {
                    _cartItems = new List<CartItem>();
                    HttpContext.Current.Session["_cartItems" + SessionManager.UserName] = _cartItems;
                }
                else                
                    _cartItems =   HttpContext.Current.Session["_cartItems" + SessionManager.UserName] as List<CartItem>;   
                return _cartItems;
            }
            //set
            //{
            //    HttpContext.Current.Session["_cartItems" + SessionManager.UserName] = _cartItems = value;
            //}
        }
        
        public static ShoppingCart Instance
        {
            get
            {
                return _instance;
            }
        }
        
        public void AddToCart(ProductItemInfo pItemInfo)
        {
            CartItem item = new CartItem(pItemInfo);

            if (item != null)
            {
                CartItem currentItem = CartItems.Where(x => x.ProductItemId == pItemInfo.ItemId).FirstOrDefault();
                if (currentItem == null)
                {
                    CartItems.Add(item);
                }
                else
                {
                    currentItem.Quantity++;
                }
            }
            //HttpContext.Current.Session["_cartItems" + SessionManager.UserName] = CartItems;      
        }
         
        public void FlushShoppingCart()
        {
            HttpContext.Current.Session["_cartItems" + SessionManager.UserName] = null;
        }
    }
}
