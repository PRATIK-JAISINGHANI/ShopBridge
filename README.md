# ShopBridge

Instructions To Start The Application

1) Open the solution with Visual Studio 2019
2) Batch Build the solution
3) In Web.Config file, Check DefaultConnection for your database connection on your system. Your System should have installed MS SQL
4) In Visual Studio, go to package manager console and run command : Update-Database -verbose. It will create a database with name ShopBridge and execute all the migration files.
5) Go to App_Data folder in a solution and check for ShopBridge.postman_collection.json. This Postman Collection contains all the Web APIs that are created with this project.
6) Make ShopBridge as startup project and run. 

Description :

As per the provided statement, I have considered more entities and made Web APIs with respect to that. I have not fully implemented Authorization part and somewhere i have skipped
some validations as well, due to time restriction. I have given approx 5 hours to build this, but it not fully complete as per the product. You can review my work with this sample.

Entities I have considered :

1) User : This entity is responsible to store User info, it can be a Customer / Admin/ Sales Person, etc. ( Role wise bifurcation is not implememted )
2) UserCredentials : This entity is responsible to store credentials for all the users. It is having One to Many relationship with User. As User, can have multiple passwords out of which one password will be active, so made its separate entity.
3) Category : This entity is responsible to make a category for an Item. Categories can of any type and there can be sub-catgory as well for eg: Men -> Shirts -> Being Human -> Shirt-01 ( Item ). so There is a field ParentCategoryId in Category entity, that will refer to an entry in Category Table.
4) Items : This entity is responsible to store data related to product and it can be tagged in any category. But there are cases that some Items contain its variants by size, color, etc. So I made a separated entity i.e ItemVariants
5) ItemVariants : This entity will have a foreign reference with Item, and it will be used to store variant of same product by size and its price. Some product might have different prices on the basis of Size, so kept it on ItemVariants level.

