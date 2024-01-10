
# e-Dükkan

An e-commerce website for testing purposes. Can be used with necessary back-end integrations. 




## Contributors 

- [@talhayay11](https://github.com/talhayay11) for MVC5 connections between front - back.
- [@deryacoban](https://github.com/deryacoban) for Back-end integration and development.
  
## xMind map for fully developed app

![WhatsApp Image 2024-01-07 at 19 20 25](https://github.com/hyphesus/commercialSite/assets/72172084/bb75727f-1314-4f7f-9d31-da9a59145cd9)


  
# e-Dükkan

An e-commerce website for testing purposes. Can be used with necessary back-end integrations. 




## What to download

This website has been created via MVC5, .NET and Microsoft SQL Server. Required Bootstrap , css and font files are in their corresponding directory. If any visual problem occurs, you may need to update these programs/files. Some files may not work due to ASP.NET software, please keep consider if you are having programs running this project on your PC.



  
## For creating new pages

Add a new controller for your new page in Controllers folder.
```c#
  public class yourController : Controller
    {
         public IActionResult yourPage()
        {
            
            // Corresponding view file for your page.
             return View();
        }

```
Add your designed page file's .cshtml version to your View folder. 
