using System;
using System.Collections.Generic;
using System.Linq;
using _3EndTDataLayer;
using _3EndTDataLayer.domain;

namespace _3EndTBusinessLayer
{
    public class TierManager
    {
        public static bool InsertTier(Tier tt)
        {
            if (tt.IsDefault == true)
            {
                var tiers = SQLHelper.GetTiers();
                List<Tier> dbTier = tiers.Where(x => x.IsDefault == true).ToList();
                foreach (Tier tier in dbTier)
                {
                    tier.IsDefault = false;
                }
            }

            var retval = SQLHelper.InsertTier(tt);
            if (retval > 0)
                return true;
            return false;
        }
      
        public static Tier GetTierById(int id)
        {
            return SQLHelper.GetTierById(id);
        }

        public static List<Tier> GetTiers(bool showActiveOnly=true)
        {
            var tiers = SQLHelper.GetTiers();
            if (showActiveOnly)
                tiers = tiers.Where(x => x.IsActive == true).ToList();
            return tiers;
        }

        public static bool UpdateTier(Tier Tier)
        {
            var tiers = SQLHelper.GetTiers();
            if (Tier.IsDefault == true)
            {
                List<Tier> dbTier = tiers.Where(x => x.IsDefault == true).ToList();
                foreach (Tier tier in dbTier)
                {
                    tier.IsDefault = false;
                }
            }

            Tier tt = tiers.Where(x => x.TierId == Tier.TierId).FirstOrDefault();
            tt.TierName = Tier.TierName;
            tt.IsDefault = Tier.IsDefault;
            tt.IsActive = Tier.IsActive;
            var retval = SQLHelper.UpdateTier(tt);
            if (retval > 0)
                return true;
            return false;
        }

        public static Boolean CheckIfTierAlreadyExist(Tier dbTier)
        {
            var tiers = SQLHelper.GetTiers();
            var tier = tiers.Where(x => x.TierName.ToLower() == dbTier.TierName.ToLower()).FirstOrDefault();
            if (tier == null) 
                return false;
            else
                return true;
        }

        //public static List<TierProductPrice> GetTierProductPriceByTierId(int Tierid)
        //{
        //    EndtCommerceEntities ECE = new EndtCommerceEntities();
        //    return ECE.TierProductPrices.Where(x => x.TierProduct.Tier.TierId == Tierid).ToList();
        //}
        //public static List<TierProduct> GetAllTierProductListByTierId(int id)
        //{
        //    EndtCommerceEntities ECE = new EndtCommerceEntities();
        //    List<TierProduct> TierProduct = ECE.TierProducts.Where(x => x.TierId == id).ToList();
        //    return TierProduct;
        //}
        //public static List<GetAssociatedProductWithTier_Result> GetAllTierProductByTierId(int id)
        //{
        //    EndtCommerceEntities ECE = new EndtCommerceEntities();
        //    List<GetAssociatedProductWithTier_Result> TierProduct = ECE.GetAssociatedProductWithTier(id).ToList();
        //    return TierProduct;
        //}

        //public static bool AddTiertProductPrice(TierProductPrice dbTierProductPrice)
        //{
        //    try
        //    {
        //        EndtCommerceEntities ECE = new EndtCommerceEntities();
        //        ECE.AddToTierProductPrices(dbTierProductPrice);
        //        ECE.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static Boolean CheckIfTierProductPriceAlreadyExist(TierProductPrice dbTierProductPrice)
        //{
        //    EndtCommerceEntities ECE = new EndtCommerceEntities();
        //    TierProductPrice TierProductPrice = ECE.TierProductPrices.Where(x => x.RetailPrice == dbTierProductPrice.RetailPrice && x.PreferredPrice == dbTierProductPrice.PreferredPrice&&
        //        x.TierProductPriceId != dbTierProductPrice.TierProductPriceId).FirstOrDefault();
        //    if (TierProductPrice == null) return false;
        //    else return true;

        //}
        //public static Boolean CheckDefaultTier(Tier dbTier)
        //{
        //    EndtCommerceEntities ECE = new EndtCommerceEntities();
        //    Tier tier = ECE.Tiers.Where(x => x.IsDefault == dbTier.IsDefault).FirstOrDefault();
        //    if (tier == null)
        //    {
        //        return false;
        //    }
        //    else return true;
        //}
        //public static Boolean CheckIfDefaultTierAlreadyExist(Tier dbTier)
        //{
        //    EndtCommerceEntities ECE = new EndtCommerceEntities();
        //    try
        //    {
        //        List<Tier> dbadvertisement = ECE.Tiers.Where(x => x.TierId != dbTier.TierId && x.IsDefault == true).ToList();
        //        //Tier Tier = ECE.Tiers.Where(x => x.TierName.ToLower() == dbTier.TierName.ToLower() && x.TierId != dbTier.TierId&&x.IsDefault==true).FirstOrDefault();
        //        foreach (Tier tier in dbadvertisement)
        //        {
        //            if (tier.IsDefault == true)
        //            {
        //                return true;
        //            }
        //            else
        //                return true;
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool AddTiertProductPrice(List<TierProductPrice> tierProductPrices)
        //{
        //    try
        //    {
        //        EndtCommerceEntities ECE = new EndtCommerceEntities();

        //        foreach (TierProductPrice tpp in tierProductPrices)
        //        {
        //            TierProductPrice dbTireProductPrice = ECE.TierProductPrices.Where(x => x.TierProductId == tpp.TierProductId).FirstOrDefault();
        //            if (dbTireProductPrice != null)
        //            {
        //                dbTireProductPrice.Price = tpp.Price;
        //            }
        //            else
        //            {
        //                ECE.TierProductPrices.AddObject(tpp);
        //                List<Customer> customers = ECE.Customers.Where(x => x.Company.TierId == tpp.TierProduct.TierId).ToList();
        //                foreach (Customer c in customers)
        //                {
        //                    CustomerTierProductPrice ctpp = new CustomerTierProductPrice();

        //                    ctpp.CustomerId = c.CustomerId;
        //                    ctpp.TierProductId = (Int64)tpp.TierProductId;
        //                    ctpp.SpecialPrice = tpp.Price;

        //                    ECE.AddToCustomerTierProductPrices(ctpp);
        //                    ECE.SaveChanges();
        //                }


        //            }

        //        }

        //        //foreach (TierProductPrice tppps in tierProductPrices)
        //        //{
        //        //        List<Customer> customers = ECE.Customers.Where(x => x.TierId == tppps.TierProduct.TierId).ToList();
        //        //        foreach (Customer c in customers)
        //        //       {
        //        //            CustomerTierProductPrice ctpp = new CustomerTierProductPrice();

        //        //            ctpp.CustomerId = c.CustomerId;
        //        //            ctpp.TierProductId = (Int64)tppps.TierProductId;
        //        //            ctpp.SpecialPrice = tppps.RetailPrice;

        //        //            ECE.AddToCustomerTierProductPrices(ctpp);
        //        //            ECE.SaveChanges();
        //        //        }

        //        //}


        //        ECE.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}

        //public static bool ApplyCustomerTier(List<Customer> SelectedCustomers)
        //{
        //    EndtCommerceEntities ECE = new EndtCommerceEntities();
        //    foreach (Customer c in SelectedCustomers)
        //    {
        //        Customer dbCustomer = ECE.Customers.Where(x => x.CustomerId == c.CustomerId).FirstOrDefault();
        //        if (dbCustomer != null)
        //        {
        //            dbCustomer.Company.TierId = c.Company.TierId;                   
        //        }
        //    }
        //    ECE.SaveChanges();
        //    return true;
        //}
        //public static bool ApplyCustomerTierProductPrices(List<Customer> selectedCustomers, List<CustomerTierProductPrice> customerTireProductPrices)
        //{
        //    EndtCommerceEntities ECE = new EndtCommerceEntities();
        //    //Initially Assign the SelectedTier for each of the selected Customer.
        //    //
        //    foreach (Customer c in selectedCustomers)
        //    {
        //        Customer dbCustomer = ECE.Customers.Where(x => x.CustomerId == c.CustomerId).FirstOrDefault();
        //        if (dbCustomer != null)
        //        {
        //            dbCustomer.Company.TierId = c.Company.TierId;

        //            //Apply the prices to each of the customer selected for each of the product define in TierProductPrice.
        //            foreach (CustomerTierProductPrice ctpp in customerTireProductPrices)
        //            {
        //                ECE.CustomerTierProductPrices.AddObject(ctpp);
        //            }
        //        }
        //    }
        //    ECE.SaveChanges();
        //    return true;
        //}


        //public static List<GetTierProductPriceByTierId_Result> GetAllTierProductPricesByTierId(int TierId)
        //{
        //    EndtCommerceEntities ECE = new EndtCommerceEntities();
        //    return ECE.GetTierProductPriceByTierId(TierId).ToList();
        //}

        //public static Tier GetDefaultTier()
        //{
        //    EndtCommerceEntities ECE = new EndtCommerceEntities();
        //    return ECE.Tiers.Where(x => x.IsDefault == true).FirstOrDefault();
        //}
    }
}
