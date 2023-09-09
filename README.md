# OOP.NET_project_Galic
C#.NET app project for FIFA world CUP

Data Layer    
Overview  
The Data Layer serves both client applications, handling data operations. It fetches data from the API, parses and maps it, prepares data for clients, and can store and read data from text files. It interacts with these API endpoints:  
Teams Results  
Matches  
Matches by Country  
Data retrieval can also use JSON files. Users can configure the data source in the settings file.  

API Exploration  
To explore the API:  

Use Mozilla Firefox or install JSONView for Google Chrome.  
Consider Postman for advanced API testing.  
Utilize tools like QuickType for data parsing.  
Client Project Notes  
Exception Handling  
Both client apps should handle exceptions gracefully, displaying informative error messages instead of crashing.  

Resource Paths  
Avoid hard-coding resource paths; use relative paths for portability.


Windows Forms Application    

Initial Settings  
Users select their preferred tournament and language at startup, saved for future sessions.  

Favorite Team  
Users choose a favorite national team. The choice persists.  

Favorite Players  
Users select three favorite players from the team's lineup. Selections persist, and drag-and-drop allows easy management.  

Player Images  
Set player images stored in the application's resources.  

Leaderboards  
View leaderboards based on goals and yellow cards.  

Exiting app  
Confirm before closing the application.  


Windows Presentation Foundation (WPF) Application    

Initial Settings  
Users configure their preferred settings and view mode. Settings persist.  

Team Selection  
Select favorite and opposing teams and view match results.  

Player Lineup  
View and manage player lineups.  

Player Details  
Click on players to view detailed information.  

Exiting  
Confirm before closing the application.    


Conclusion  
The Data Layer ensures efficient data management for both client apps, offering features like match exploration, team and player selection, leaderboards, and printing. The apps prioritize user experience and graceful error handling.
