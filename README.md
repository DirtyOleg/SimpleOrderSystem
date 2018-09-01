# SimpleOrderSystem
The project is a practice for myself as a way to pick up ADO.NET again. 

Goal:
Develop a ordering system for a small restaurant. Since this is just a pratice, the funcationalities include in this project is simple and  less than any commercial ordering product.

How to run this project:
1. Run the setup.sql script under /Supporting Files/ directory. NOTE: this project is developed based on Microsoft SQL Server, if you use other database, please modify the script correspondingly. Also, check other files inside the same folder for detail about the database structure.
2. Open App.config file under /PresentationLayer/ directory. Change the credential infomation correspondingly.
3. Then you can start the project. NOTE: the default account for manager is ID:1 Pwd:456, and for employee is ID:2 Pwd:123, the functionality provided to manager and employee is different, so try both one


Update 09/01/2018:
I decided to stop develop this project, up to now, the following functionalities are fully completed:
Login, Member Management, Membership Management

There are two reasons to prevent me from continuing:
1. the primary goal of this project is to enhance my skill and memoey about ADO.NET and SQL. By finishing those three forms mentioned above, I think the goal have already achieved. The rest of the forms, such as Table Management, Dish management, Order Management, are pretty similar to those finished form.
2. With the publish of C# 7 and .Net Core, the traditional ADO.NET and ASP.NET will be obselete someday in the future, there is no need to continue creating project based on the old technologies. I decide to spend more time on the learning of ASP.NET Core.
