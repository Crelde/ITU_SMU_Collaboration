 
# Mega git cleanup!

'master' is now the only branch. Only stable commits may be made to master branch.

## How to clean up and bring your repo back up to speed

First off, fetch all commits. Then use Git Extensions to 'checkout' origin/master branch.
 (Make sure to have selected "Reset local branch with the name: 'master'" when checking out)
Your 'master' branch should now be the furthest ahead.

Then go to Remotes -> Manage Remote Repositories -> Default Pull Behavior and press the "prune remote branches" button.
 This will remove all references to old and deleted remote branches.
 
You can then delete all old local (red) branches from your repository, leaving only the local 'master' branch and the remote 'origin/master' branch.

Congratulations, clean git for you!
 
 
 
 
## Instructions on proper git usage
 Please branch off master when you need to work. when your work is done (and succesfully building), you can merge back into master.
 

 If I see anyone doing unstable commits to master branch, 
 I will murder you!

 regards, Kasra ;)
