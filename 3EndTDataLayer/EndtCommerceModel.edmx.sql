
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/03/2014 06:52:56
-- Generated from EDMX file: C:\Users\Aditi\Source\Workspaces\3EndtShop\SolutionX\3EndTDataLayer\EndtCommerceModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [3EndTCommerce];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PurchaseOrderMaster_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseOrderMasters] DROP CONSTRAINT [FK_PurchaseOrderMaster_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductInventory_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductInventories] DROP CONSTRAINT [FK_ProductInventory_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_TierProduct_Tier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TierProducts] DROP CONSTRAINT [FK_TierProduct_Tier];
GO
IF OBJECT_ID(N'[dbo].[FK_TierProductPrice_TierProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TierProductPrices] DROP CONSTRAINT [FK_TierProductPrice_TierProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRoleCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [FK_UserRoleCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_CategoryProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseOrderMasterPurchaseOrderDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseOrderDetails] DROP CONSTRAINT [FK_PurchaseOrderMasterPurchaseOrderDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderStatusPurchaseOrderMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseOrderMasters] DROP CONSTRAINT [FK_OrderStatusPurchaseOrderMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductPurchaseOrderDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseOrderDetails] DROP CONSTRAINT [FK_ProductPurchaseOrderDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [FK_CompanyCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyTierProductPrice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TierProductPrices] DROP CONSTRAINT [FK_CompanyTierProductPrice];
GO
IF OBJECT_ID(N'[dbo].[FK_ParentCompanyCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Companies] DROP CONSTRAINT [FK_ParentCompanyCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_TierCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Companies] DROP CONSTRAINT [FK_TierCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductItemPurchaseOrderDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseOrderDetails] DROP CONSTRAINT [FK_ProductItemPurchaseOrderDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductItemTierProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TierProducts] DROP CONSTRAINT [FK_ProductItemTierProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductFilterProductItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductItems] DROP CONSTRAINT [FK_ProductFilterProductItem];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductProductItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductItems] DROP CONSTRAINT [FK_ProductProductItem];
GO
IF OBJECT_ID(N'[dbo].[FK_FilterTypesFilter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Filters] DROP CONSTRAINT [FK_FilterTypesFilter];
GO
IF OBJECT_ID(N'[dbo].[FK_FilterProductFilter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductFilters] DROP CONSTRAINT [FK_FilterProductFilter];
GO
IF OBJECT_ID(N'[dbo].[FK_AddressPurchaseOrderMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseOrderMasters] DROP CONSTRAINT [FK_AddressPurchaseOrderMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_CompanyAddress];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[ProductInventories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductInventories];
GO
IF OBJECT_ID(N'[dbo].[PurchaseOrderDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseOrderDetails];
GO
IF OBJECT_ID(N'[dbo].[PurchaseOrderMasters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseOrderMasters];
GO
IF OBJECT_ID(N'[dbo].[Tiers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tiers];
GO
IF OBJECT_ID(N'[dbo].[TierProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TierProducts];
GO
IF OBJECT_ID(N'[dbo].[TierProductPrices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TierProductPrices];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[OrderStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderStatus];
GO
IF OBJECT_ID(N'[dbo].[ParentCompanies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParentCompanies];
GO
IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[ProductFilters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductFilters];
GO
IF OBJECT_ID(N'[dbo].[ProductItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductItems];
GO
IF OBJECT_ID(N'[dbo].[FilterTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilterTypes];
GO
IF OBJECT_ID(N'[dbo].[Filters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Filters];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryId] int IDENTITY(1,1) NOT NULL,
    [CategoryName] varchar(250)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CategoryLevel] smallint  NOT NULL,
    [ParentCategoryId] int  NULL,
    [ImageUrl] varchar(250)  NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerId] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(250)  NULL,
    [LastName] varchar(250)  NULL,
    [IsActive] bit  NOT NULL,
    [IsEmailSend] bit  NULL,
    [UserName] varchar(250)  NOT NULL,
    [Password] varchar(250)  NOT NULL,
    [RoleId] int  NOT NULL,
    [EMailId] varchar(250)  NULL,
    [PhoneNumber] varchar(20)  NULL,
    [FaxNumber] varchar(20)  NULL,
    [CompanyId] int  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductId] int IDENTITY(1,1) NOT NULL,
    [ProductTitle] varchar(250)  NOT NULL,
    [Description] varchar(max)  NULL,
    [Unit] varchar(100)  NULL,
    [ImageUrl] varchar(max)  NULL,
    [IsActive] bit  NOT NULL,
    [CategoryId] int  NOT NULL
);
GO

-- Creating table 'ProductInventories'
CREATE TABLE [dbo].[ProductInventories] (
    [ProductInventoryId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [QuantityInStock] decimal(18,2)  NOT NULL,
    [ProductAddedDate] datetime  NOT NULL,
    [IsStockCleared] bit  NOT NULL
);
GO

-- Creating table 'PurchaseOrderDetails'
CREATE TABLE [dbo].[PurchaseOrderDetails] (
    [PurchaseOrderDetailId] int IDENTITY(1,1) NOT NULL,
    [Quantity] int  NOT NULL,
    [PurchaseOrderId] int  NOT NULL,
    [TotalProductPrice] decimal(19,4)  NOT NULL,
    [ProductItemId] int  NOT NULL,
    [ProductId] int  NOT NULL,
    [UnitPrice] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'PurchaseOrderMasters'
CREATE TABLE [dbo].[PurchaseOrderMasters] (
    [PurchaseOrderId] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [OrderDate] datetime  NOT NULL,
    [PurchaseOrderNumber] varchar(50)  NOT NULL,
    [ConfirmationNumber] varchar(20)  NULL,
    [ConfirmationSendDate] datetime  NULL,
    [DateShipped] datetime  NULL,
    [Comments] varchar(500)  NULL,
    [ShippingCost] decimal(19,4)  NULL,
    [OrderStatusId] int  NOT NULL,
    [CompanyShippingAddressId] int  NOT NULL,
    [BillingAddressId] int  NOT NULL
);
GO

-- Creating table 'Tiers'
CREATE TABLE [dbo].[Tiers] (
    [TierId] int IDENTITY(1,1) NOT NULL,
    [TierName] varchar(250)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [IsDefault] bit  NULL
);
GO

-- Creating table 'TierProducts'
CREATE TABLE [dbo].[TierProducts] (
    [TierProductId] int IDENTITY(1,1) NOT NULL,
    [TierId] int  NOT NULL,
    [ProductItemId] int  NOT NULL
);
GO

-- Creating table 'TierProductPrices'
CREATE TABLE [dbo].[TierProductPrices] (
    [TierProductPriceId] int IDENTITY(1,1) NOT NULL,
    [TierProductId] int  NULL,
    [Price] decimal(19,4)  NULL,
    [SpecialCompanyId] int  NULL,
    [SpecialDiscountPercent] decimal(10,4)  NULL,
    [SpecialDiscountPrice] decimal(19,4)  NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] varchar(250)  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'OrderStatus'
CREATE TABLE [dbo].[OrderStatus] (
    [OrderStatusId] int IDENTITY(1,1) NOT NULL,
    [IsActive] bit  NOT NULL,
    [Status] nvarchar(250)  NOT NULL
);
GO

-- Creating table 'ParentCompanies'
CREATE TABLE [dbo].[ParentCompanies] (
    [ParentCompanyId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [FederalId] nvarchar(20)  NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [CompanyId] int IDENTITY(1,1) NOT NULL,
    [CompanyName] varchar(250)  NOT NULL,
    [FederalId] varchar(20)  NULL,
    [IsActive] bit  NOT NULL,
    [TierId] int  NOT NULL,
    [IsSpecial] bit  NOT NULL,
    [PhoneNumber] varchar(20)  NOT NULL,
    [FaxNumber] varchar(20)  NULL,
    [EMailId] varchar(250)  NULL,
    [ParentCompanyId] int  NULL
);
GO

-- Creating table 'ProductFilters'
CREATE TABLE [dbo].[ProductFilters] (
    [ProductFilterId] int IDENTITY(1,1) NOT NULL,
    [PrimaryFilterId] int  NOT NULL,
    [SecondaryFilterId] int  NOT NULL
);
GO

-- Creating table 'ProductItems'
CREATE TABLE [dbo].[ProductItems] (
    [ProductItemId] int IDENTITY(1,1) NOT NULL,
    [ProductSKU] nvarchar(100)  NOT NULL,
    [ProductFilterId] int  NOT NULL,
    [ProductId] int  NOT NULL
);
GO

-- Creating table 'FilterTypes'
CREATE TABLE [dbo].[FilterTypes] (
    [FilterTypeId] int IDENTITY(1,1) NOT NULL,
    [FilterTypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Filters'
CREATE TABLE [dbo].[Filters] (
    [FilterId] int IDENTITY(1,1) NOT NULL,
    [FilterTypeId] int  NOT NULL,
    [FilterValue] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressId] int IDENTITY(1,1) NOT NULL,
    [CompanyId] int  NOT NULL,
    [AddressName] nvarchar(250)  NULL,
    [AddressLine1] nvarchar(1000)  NOT NULL,
    [AddressLine2] nvarchar(1000)  NULL,
    [City] nvarchar(250)  NOT NULL,
    [State] nvarchar(3)  NOT NULL,
    [Zipcode] nvarchar(10)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [IsPrimary] bit  NOT NULL,
    [Type] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CategoryId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- Creating primary key on [CustomerId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [ProductId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [ProductInventoryId] in table 'ProductInventories'
ALTER TABLE [dbo].[ProductInventories]
ADD CONSTRAINT [PK_ProductInventories]
    PRIMARY KEY CLUSTERED ([ProductInventoryId] ASC);
GO

-- Creating primary key on [PurchaseOrderDetailId] in table 'PurchaseOrderDetails'
ALTER TABLE [dbo].[PurchaseOrderDetails]
ADD CONSTRAINT [PK_PurchaseOrderDetails]
    PRIMARY KEY CLUSTERED ([PurchaseOrderDetailId] ASC);
GO

-- Creating primary key on [PurchaseOrderId] in table 'PurchaseOrderMasters'
ALTER TABLE [dbo].[PurchaseOrderMasters]
ADD CONSTRAINT [PK_PurchaseOrderMasters]
    PRIMARY KEY CLUSTERED ([PurchaseOrderId] ASC);
GO

-- Creating primary key on [TierId] in table 'Tiers'
ALTER TABLE [dbo].[Tiers]
ADD CONSTRAINT [PK_Tiers]
    PRIMARY KEY CLUSTERED ([TierId] ASC);
GO

-- Creating primary key on [TierProductId] in table 'TierProducts'
ALTER TABLE [dbo].[TierProducts]
ADD CONSTRAINT [PK_TierProducts]
    PRIMARY KEY CLUSTERED ([TierProductId] ASC);
GO

-- Creating primary key on [TierProductPriceId] in table 'TierProductPrices'
ALTER TABLE [dbo].[TierProductPrices]
ADD CONSTRAINT [PK_TierProductPrices]
    PRIMARY KEY CLUSTERED ([TierProductPriceId] ASC);
GO

-- Creating primary key on [RoleId] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [OrderStatusId] in table 'OrderStatus'
ALTER TABLE [dbo].[OrderStatus]
ADD CONSTRAINT [PK_OrderStatus]
    PRIMARY KEY CLUSTERED ([OrderStatusId] ASC);
GO

-- Creating primary key on [ParentCompanyId] in table 'ParentCompanies'
ALTER TABLE [dbo].[ParentCompanies]
ADD CONSTRAINT [PK_ParentCompanies]
    PRIMARY KEY CLUSTERED ([ParentCompanyId] ASC);
GO

-- Creating primary key on [CompanyId] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([CompanyId] ASC);
GO

-- Creating primary key on [ProductFilterId] in table 'ProductFilters'
ALTER TABLE [dbo].[ProductFilters]
ADD CONSTRAINT [PK_ProductFilters]
    PRIMARY KEY CLUSTERED ([ProductFilterId] ASC);
GO

-- Creating primary key on [ProductItemId] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [PK_ProductItems]
    PRIMARY KEY CLUSTERED ([ProductItemId] ASC);
GO

-- Creating primary key on [FilterTypeId] in table 'FilterTypes'
ALTER TABLE [dbo].[FilterTypes]
ADD CONSTRAINT [PK_FilterTypes]
    PRIMARY KEY CLUSTERED ([FilterTypeId] ASC);
GO

-- Creating primary key on [FilterId] in table 'Filters'
ALTER TABLE [dbo].[Filters]
ADD CONSTRAINT [PK_Filters]
    PRIMARY KEY CLUSTERED ([FilterId] ASC);
GO

-- Creating primary key on [AddressId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'PurchaseOrderMasters'
ALTER TABLE [dbo].[PurchaseOrderMasters]
ADD CONSTRAINT [FK_PurchaseOrderMaster_Customer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseOrderMaster_Customer'
CREATE INDEX [IX_FK_PurchaseOrderMaster_Customer]
ON [dbo].[PurchaseOrderMasters]
    ([CustomerId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductInventories'
ALTER TABLE [dbo].[ProductInventories]
ADD CONSTRAINT [FK_ProductInventory_Product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductInventory_Product'
CREATE INDEX [IX_FK_ProductInventory_Product]
ON [dbo].[ProductInventories]
    ([ProductId]);
GO

-- Creating foreign key on [TierId] in table 'TierProducts'
ALTER TABLE [dbo].[TierProducts]
ADD CONSTRAINT [FK_TierProduct_Tier]
    FOREIGN KEY ([TierId])
    REFERENCES [dbo].[Tiers]
        ([TierId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TierProduct_Tier'
CREATE INDEX [IX_FK_TierProduct_Tier]
ON [dbo].[TierProducts]
    ([TierId]);
GO

-- Creating foreign key on [TierProductId] in table 'TierProductPrices'
ALTER TABLE [dbo].[TierProductPrices]
ADD CONSTRAINT [FK_TierProductPrice_TierProduct]
    FOREIGN KEY ([TierProductId])
    REFERENCES [dbo].[TierProducts]
        ([TierProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TierProductPrice_TierProduct'
CREATE INDEX [IX_FK_TierProductPrice_TierProduct]
ON [dbo].[TierProductPrices]
    ([TierProductId]);
GO

-- Creating foreign key on [RoleId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_UserRoleCustomer]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[UserRoles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRoleCustomer'
CREATE INDEX [IX_FK_UserRoleCustomer]
ON [dbo].[Customers]
    ([RoleId]);
GO

-- Creating foreign key on [CategoryId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_CategoryProduct]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([CategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryProduct'
CREATE INDEX [IX_FK_CategoryProduct]
ON [dbo].[Products]
    ([CategoryId]);
GO

-- Creating foreign key on [PurchaseOrderId] in table 'PurchaseOrderDetails'
ALTER TABLE [dbo].[PurchaseOrderDetails]
ADD CONSTRAINT [FK_PurchaseOrderMasterPurchaseOrderDetail]
    FOREIGN KEY ([PurchaseOrderId])
    REFERENCES [dbo].[PurchaseOrderMasters]
        ([PurchaseOrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseOrderMasterPurchaseOrderDetail'
CREATE INDEX [IX_FK_PurchaseOrderMasterPurchaseOrderDetail]
ON [dbo].[PurchaseOrderDetails]
    ([PurchaseOrderId]);
GO

-- Creating foreign key on [OrderStatusId] in table 'PurchaseOrderMasters'
ALTER TABLE [dbo].[PurchaseOrderMasters]
ADD CONSTRAINT [FK_OrderStatusPurchaseOrderMaster]
    FOREIGN KEY ([OrderStatusId])
    REFERENCES [dbo].[OrderStatus]
        ([OrderStatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderStatusPurchaseOrderMaster'
CREATE INDEX [IX_FK_OrderStatusPurchaseOrderMaster]
ON [dbo].[PurchaseOrderMasters]
    ([OrderStatusId]);
GO

-- Creating foreign key on [ProductId] in table 'PurchaseOrderDetails'
ALTER TABLE [dbo].[PurchaseOrderDetails]
ADD CONSTRAINT [FK_ProductPurchaseOrderDetail]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductPurchaseOrderDetail'
CREATE INDEX [IX_FK_ProductPurchaseOrderDetail]
ON [dbo].[PurchaseOrderDetails]
    ([ProductId]);
GO

-- Creating foreign key on [CompanyId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_CompanyCustomer]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([CompanyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyCustomer'
CREATE INDEX [IX_FK_CompanyCustomer]
ON [dbo].[Customers]
    ([CompanyId]);
GO

-- Creating foreign key on [SpecialCompanyId] in table 'TierProductPrices'
ALTER TABLE [dbo].[TierProductPrices]
ADD CONSTRAINT [FK_CompanyTierProductPrice]
    FOREIGN KEY ([SpecialCompanyId])
    REFERENCES [dbo].[Companies]
        ([CompanyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyTierProductPrice'
CREATE INDEX [IX_FK_CompanyTierProductPrice]
ON [dbo].[TierProductPrices]
    ([SpecialCompanyId]);
GO

-- Creating foreign key on [ParentCompanyId] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [FK_ParentCompanyCompany]
    FOREIGN KEY ([ParentCompanyId])
    REFERENCES [dbo].[ParentCompanies]
        ([ParentCompanyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ParentCompanyCompany'
CREATE INDEX [IX_FK_ParentCompanyCompany]
ON [dbo].[Companies]
    ([ParentCompanyId]);
GO

-- Creating foreign key on [TierId] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [FK_TierCompany]
    FOREIGN KEY ([TierId])
    REFERENCES [dbo].[Tiers]
        ([TierId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TierCompany'
CREATE INDEX [IX_FK_TierCompany]
ON [dbo].[Companies]
    ([TierId]);
GO

-- Creating foreign key on [ProductItemId] in table 'PurchaseOrderDetails'
ALTER TABLE [dbo].[PurchaseOrderDetails]
ADD CONSTRAINT [FK_ProductItemPurchaseOrderDetail]
    FOREIGN KEY ([ProductItemId])
    REFERENCES [dbo].[ProductItems]
        ([ProductItemId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductItemPurchaseOrderDetail'
CREATE INDEX [IX_FK_ProductItemPurchaseOrderDetail]
ON [dbo].[PurchaseOrderDetails]
    ([ProductItemId]);
GO

-- Creating foreign key on [ProductItemId] in table 'TierProducts'
ALTER TABLE [dbo].[TierProducts]
ADD CONSTRAINT [FK_ProductItemTierProduct]
    FOREIGN KEY ([ProductItemId])
    REFERENCES [dbo].[ProductItems]
        ([ProductItemId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductItemTierProduct'
CREATE INDEX [IX_FK_ProductItemTierProduct]
ON [dbo].[TierProducts]
    ([ProductItemId]);
GO

-- Creating foreign key on [ProductFilterId] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [FK_ProductFilterProductItem]
    FOREIGN KEY ([ProductFilterId])
    REFERENCES [dbo].[ProductFilters]
        ([ProductFilterId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductFilterProductItem'
CREATE INDEX [IX_FK_ProductFilterProductItem]
ON [dbo].[ProductItems]
    ([ProductFilterId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductItems'
ALTER TABLE [dbo].[ProductItems]
ADD CONSTRAINT [FK_ProductProductItem]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductItem'
CREATE INDEX [IX_FK_ProductProductItem]
ON [dbo].[ProductItems]
    ([ProductId]);
GO

-- Creating foreign key on [FilterTypeId] in table 'Filters'
ALTER TABLE [dbo].[Filters]
ADD CONSTRAINT [FK_FilterTypesFilter]
    FOREIGN KEY ([FilterTypeId])
    REFERENCES [dbo].[FilterTypes]
        ([FilterTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FilterTypesFilter'
CREATE INDEX [IX_FK_FilterTypesFilter]
ON [dbo].[Filters]
    ([FilterTypeId]);
GO

-- Creating foreign key on [PrimaryFilterId] in table 'ProductFilters'
ALTER TABLE [dbo].[ProductFilters]
ADD CONSTRAINT [FK_FilterProductFilter]
    FOREIGN KEY ([PrimaryFilterId])
    REFERENCES [dbo].[Filters]
        ([FilterId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FilterProductFilter'
CREATE INDEX [IX_FK_FilterProductFilter]
ON [dbo].[ProductFilters]
    ([PrimaryFilterId]);
GO

-- Creating foreign key on [BillingAddressId] in table 'PurchaseOrderMasters'
ALTER TABLE [dbo].[PurchaseOrderMasters]
ADD CONSTRAINT [FK_AddressPurchaseOrderMaster]
    FOREIGN KEY ([BillingAddressId])
    REFERENCES [dbo].[Addresses]
        ([AddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressPurchaseOrderMaster'
CREATE INDEX [IX_FK_AddressPurchaseOrderMaster]
ON [dbo].[PurchaseOrderMasters]
    ([BillingAddressId]);
GO

-- Creating foreign key on [CompanyId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_CompanyAddress]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([CompanyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyAddress'
CREATE INDEX [IX_FK_CompanyAddress]
ON [dbo].[Addresses]
    ([CompanyId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------