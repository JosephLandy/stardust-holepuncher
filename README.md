# stardust-holepuncher
Team Stardust - Holepuncher (working title)
Hello, welcome to the readme collaborators!

I'm going to outline how to use git with this project here.

Definitions:

git - git is for tracking revisions to software on your own computer in such a way as to not over write the main stable version of the program, by keeping your work in progress in a "branch" separate from the master copy. Once your branch is working git lets you safely merge your changes into the main branch. Git also lets you "push" your local changes to a server, and new versions online can be downloaded and merged with your local version. You can select which branches you want to sync. So you can keep some branches exclusively local if you want. Changes can be easily reverted, because git keeps a history of your commits. Commits sort of make changes official, and you have to commit your changes before pushing. 

github - a server for git that provides nice features and a cool interface. 

github desktop - much easier interface for git. Especially with pushing to the server.


I realized I am not writing this in a branch right now, so I am going to do that. First I am going to commit what I have to master though. 
Ok, I'm writing this in a branch now. 

What you need to do to get connected and setup is as follows: Once you are a collaborator, you should be able to:
1. open github desktop
2. click the + symbol at the top left corner of the window
3. go to the clone tab in the drop down
4. select "stardust-holepuncher" and hit clone. 
5. it will now be cloned locally, and if you hit "publish", or "sync" it should sync everything.

So yeah, you now have the project. 

What you have downloaded:
1. stardust-holepuncher folder. With partial unity project.
2. jlTestScene. (doesn't contain anything, it was just a test)
3. ".gitignore" will appear as a file without a name on windows. 
The stardust-holepuncher folder is the root folder which is tracked by git. However, it's set to not track some parts of the unity project which it would be better to have remain local.
Of the standard Unity Project folders it is tracking is the assets folder and the ProjectSettings folder, so what you have downloaded is not a complete project.
Fortuneately when you double click on the jlTestScene it will automatically generate the remaining project components for you and you will only have to do this once. 

When you first clone the project locally you will have to:
1. navigate to the folder where you cloned it, go to the assets/scenes folder
2. double click the scene file to autogenerate a full project and open the file


Regarding branches:
It's easy to create branches, you just hit the create branch button. And give it a name etc. It's also easy to merge branches, but I have written quite a lot right now, so I will talk a bit more about that later. 

You can have as many branches as you want and you can branch from any existing branch, not just off of master. 

But yeah, basically it's better to do work in a branch, and then merge it later into master. 


I hope I didn't make this seem to complicated, it's actually really quite simple. One nice thing with git is that it's actually really hard to mess things up. Everything stays really clean and tidy and if something goes wrong it's easy to revert that, so don't be afraid to experiment!! 

I actually completely love git now. i <3 git. 

I am going to commit these changes, merge them with the master branch, and sync it with the server now. 

<<<<<<< Updated upstream
This might be a really incoherent explanation, 
=======
This might be a really incoherent explanation, so please ask if you have any questions or would like some clarification. It seems kind of weird, but it's actually really simple! :)
>>>>>>> Stashed changes
