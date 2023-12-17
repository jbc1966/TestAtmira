-----------------------------------
------  ASP NET CORE WEB API ------
-----------------------------------

Created by: Josep A. Baranda Carbonell
--------------------------------------

Regarding to this solution, after evaluate different possibilities
I have created an Asp.NET Core Web Api
Net core version: 8.0

Test solution: F5 and wait for swagger to be started.
Implementation of database has been Microsoft.EntityFrameworkCore.InMemory

There are two methods created:
1-   GetEpisode(int id, bool saveDataLoaded=false)
2-  GetEpisodes()

In Method number 1, has been added a new parameter regarding to
if you want to store the data obtained.

If you select true for saveDataLoaded, the value obtained will be saved into InMemory database
How to check saved value?  You can check savedvalue executing swagger method GetEpisodes()

Then, first execute method: GetEpisodes(int id, saveDataLoaded = true) (Through swagger)
Once executed, then run next method GetEpisodes()

I have added an extra method in order to add more data to database:
   public async Task<ActionResult<Episode>> PostEpisode(Episode episode)

Note:
Take into account that these methods are securized by an ApiKey, you can find ApiKey value in appSettings.json
