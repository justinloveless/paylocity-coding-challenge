# paylocity-coding-challenge

## Live Demo:
https://lovelesslabstx.com/

## Challenge Description:
<strong>Business Need:</strong> 

One of the critical functions that we provide for our clients is the ability to pay for their employees’ benefits 
packages. A portion of these costs are deducted from their paycheck, and we handle that deduction. Please 
demonstrate how you would code the following scenario: 
* The cost of benefits is $1000/year for each employee 
* Each dependent (children and possibly spouses) incurs a cost of $500/year 
* Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent 
We’d like to see this calculation used in a web application where employers input employees and their 
dependents, and get a preview of the costs. This is of course a contrived example. We want to know how you 
would implement the application structure and calculations and get a brief preview of how you work. 

<strong>Please implement a web application based on these assumptions: </strong>
* All employees are paid $2000 per paycheck before deductions 
* There are 26 paychecks in a year

## Getting Started
    
### Pre-requisites
1. Install [Node.js](https://nodejs.org/en/download/)
<!--
![node](https://user-images.githubusercontent.com/16358843/144769656-aa5b469e-bc68-4073-bcbc-f395763bc356.png)
-->

2. Install [Dotnet 6](https://dotnet.microsoft.com/download/dotnet/6.0)

<!--
![dotnet6](https://user-images.githubusercontent.com/16358843/144769655-4380ac57-47aa-42b2-9056-7de167d7c21e.png)
-->

3. Install [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)  <i>(this will be used for local development only, because production uses an Azure SQL DB)</i>
   - You may have to scroll down a bit to find it:
   
   ![sqlexpress](https://user-images.githubusercontent.com/16358843/144769043-bf063bbb-f076-4963-9627-fb33302cfce3.png)
   `

4. Make note of the connection string at the end, as we will need this later
5. Install [VS Code](https://code.visualstudio.com/download)

<!--
    ![vscode](https://user-images.githubusercontent.com/16358843/144769672-6f7bfade-a398-41e5-940e-eeed9bdb73e6.png)
-->

6. Install the "mssql" extension in VS Code
   
   ![mssql](https://user-images.githubusercontent.com/16358843/144769136-112a0b5c-251c-41b9-9c7b-8e3c9b0a75f0.png)

7. Clone this repository or download [the zip](https://github.com/justinloveless/paylocity-coding-challenge/archive/refs/heads/main.zip)

<!--
    ![git](https://user-images.githubusercontent.com/16358843/144769718-718e3310-0bc4-4ada-a1ef-1e8c18853bfb.png)
-->

### setting up the local database
8. Open <strong>PCC/API/SqlScripts/CreateTables.sql</strong>, select the entire contents of the file, and execute the query (use CTRL + SHIFT + E or hit the green play button)
    - The first time you try to execute a query, the mssql extension will ask you to provide a connection string and name the profile. The connection string should look something like this: ``` "Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;" ``` and the profile name can be whatever you want.
   
   ![mssql-connstr](https://user-images.githubusercontent.com/16358843/144769355-488c0704-4ab2-4b1c-98d8-7a140c3ed810.png)
   ![mssql-profile](https://user-images.githubusercontent.com/16358843/144769360-b7afce06-9538-409d-9adf-baed483af1d2.png)
   ![createTables](https://user-images.githubusercontent.com/16358843/144769366-a6e8f53a-b636-42ff-ac87-591e26377134.png)

9. After executing the CreateTables.sql file, it's now time to execute the SeedData.sql file in the same folder. Same procedure here: open it, select the entire contents, and execute the query
   
   ![seedData](https://user-images.githubusercontent.com/16358843/144769379-d6f11fc0-6f51-407f-85c8-07d80f0596a5.png)

### starting the API
10. Open a terminal, navigate to PCC/API/ClientApp, and run ``` npm install ```
11. Next, in the same location, run ``` npm link @angular/cli ```
    - <strong>NOTE</strong>: You may need to restart your terminals, and possible VS Code, after this step. Try running ``` ng ``` by itself to make sure that it works before moving on.
12. In a new terminal, go to PCC/API, and run ``` dotnet dev-certs https --trust ``` and if there is a popup like below, select <strong>"Yes"</strong>. 
   
   ![dev-certs](https://user-images.githubusercontent.com/16358843/144768947-d8161bc9-a54a-4f5e-ac76-8d36cc872294.png)

13. In that same terminal, you can then run ``` dotnet watch run ```. This should open a browser and show you a Swagger page where you can test all of the API endpoints.
   
   ![swagger](https://user-images.githubusercontent.com/16358843/144769452-7a89b9a3-7f2d-4acb-a059-5c14791074ab.png)

### starting the front-end
14. Finally, in another terminal, run 
```
cd PCC/API/ClientApp
ng serve 
``` 
   
This will take a while the first time, but eventually a browser tab should open with the app front-end.

Note: If the browser does not automatically launch, you can get to it by opening a browser and navigating to ``` https://localhost:4200 ```
   
   ![frontend](https://user-images.githubusercontent.com/16358843/144769536-47dac819-2dc2-4511-97f0-7616d29d2da1.png)


