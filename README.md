# D&D Campaign Manager
Repository for an app that displays a map of a role-playing game world and automates common features of [hexcrawl](https://www.runagame.net/2014/03/the-hex-crawl.html) or sandbox table-top gameplay style such as; rolling for random encounters, finding travel times between locations. As well as storing information about locations on the map and allowing the dungeon master to edit that information to customize it for their own game and update it as the game progresses. 

Using; C#, WPF, SQL, Microsoft Entity Framework

## Definition Of Done

- [ ] All user stories have been reviewed and are done
- [ ] Readme fully describes app functionality
- [ ] Readme includes breakdown of every sprint
- [ ] Cover all CRUD methods with unit tests
- [ ] Final changes committed to main branch by 9:30 Mon 17ths

## Sprint 1  - 11/05/2021

- [x] Create entity relationship diagram
- [ ] Complete user story 1.1 DM Map View

### Pre-Sprint Project Board

![](/readme_images/sprint1_presprint.png)

### Database Entity Relationship Diagram

![](readme_images/databaseERD.png)

### Sprint Review

During the sprint I realised I needed to alter my user stories, creating one for the DM Map View itself, rather than login functionality which was the initial story 1.1. This became the real focus of the sprint, blocking out the gui. I completed the ERD and blocked out a scaffold for the gui, which I can then proceed to add the underlying functionality to.

### Sprint Retrospective

I had trouble with relative uri's for loading images into the map buttons. In the current state these images are loaded from absolute uri's, which won't be acceptable for the final product. This is something I would like to fix in the next sprint. 

Focussing in particular on the gui to begin with had it's merits and demerits. I chose to do this because working with WPF is the aspect of the project I am least familiar with so I wanted to get it out of the way early and not risk getting stuck on towards the end of the project. However creating the gui in a vacuum was I think harder than expected. Without knowing what the output of functions that would be called from the business/game logic layer it was somewhat difficult to plan. That being said now that I do have a framework for the gui, which can be refactored as I add backend functionality I'm confident that I'll be building exactly those backend functions which I do need and no more.

In the next sprint I will be creating the database and CRUD functions necessary to fully implement User Story 1.1, then moving onto 2.1, which will leave me with a full set of Read and Update functions for viewing and editing province details which will be the main functionality of the app overall.

### Post-sprint Project Board

![Sprint 2 - Project Manager Post-Sprint](/readme_images/sprint1_postsprint.png)

## Sprint 2 - 12/05/2021

### Goals

- [x] Implement database from entity relationship diagram
- [x] Complete user story 1.1 DM Map View
- [x] Complete user story 2.1 Edit Province Contents

### Pre-Sprint Project Board

![](readme_images/sprint2_presprint.png)

### Sprint Review

Implemented database from ERD and all user stories from sprint.

### Sprint Retrospective

This sprint went smoother than the previous one, completed all goals. Overall I'm happy with it.

In the next sprint I will be covering user stories 1.3 and 1.4

### Post-Sprint Project Board

![](/readme_images/sprint2_postsprint.png)

## Sprint 3 - 13/05/2021

### Goals

- [ ] Complete user story 1.3 See Travel Times
- [x] Complete user story 1.4 Automatically Roll Encounters

### Pre-Sprint Project Board

![](readme_images/sprint3_presprint.png)

### Sprint Review

Completed user story 1.4, did not complete user story 1.3.

### Sprint Retrospective

Was quite heavily blocked by inexperience with working with JSON in C#, also by altering my database. I added a column to the RandomEncounters table to hold the dice associated with that set of encounters, which made the code around doing this somewhat cleaner. Spent a good hour trying to edit the database, then burn it down such that I could build it again. 

In the future I should become more familiar with methods for dealing with JSON in c#.

I also broke down the acceptance criteria for user stories 1.3 (which was in this sprint and un-completed) as well as the criteria for user story 2.2. Both User Stories were clear but the acceptance criteria was over-broad, lot's of different little bits all in one gherkin statement which meant it was not very clear exactly what the steps would be.

Tomorrow/later today I am going to attempt to go for user story 2.2 (Edit Random Encounter Tables), and generally go about sprucing up the gui from it's rudimentary state right now, this may involve drawing wire-frames.  As well as make sure as much of the CRUD and other logic in DnDCampaignManagerApp is covered in unit tests as possible.

### Post-Sprint Project Board

![](readme_images/sprint3_postsprint.png)