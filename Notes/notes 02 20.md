# 02/20/2019 Notes

## Github information
- Origin/master is the most recent idea of what github has
    - The laptop is not constantly checking with github every moment, only when you pull/push
    - Or unless you're using Visual Studio
    - Called a "remote tracking branch"
- The "master" branch on Github can also be called the "remote branch"
- The "master" branch on your laptop is the "local branch"
- You can have branches that are local and don't go to Github
    - Once finished with them, you can merge them back into "master"
- Merging:
    - When one branch is just ahead of another and not deviating, that's called a "fast forward merge"
    - Merging doesn't delete features, it tries to grab information from one branch and bring it to another
    - Don't merge while there are uncommited changes
- Think of branches like nodes with reference pointers, when you push you add a node at the end. A branch is a point to a commit that includes immediate changes and all changes going backwards
- If you Git Push while on the "master" branch, it will update the branch pointer to include the most recent changes
- If you try to Git Push a branch that isn't on Github you'll get an error, but there are ways around it with a different types of push
- Conflicts can emerge when two different people push different things to "master"
- Git pull is the shortcut for git fetch and merge
    - Git fetch is the command that updates the remote tracking branches
    - Git merge automatically merges the "remote tracking branch" into the current branch
- The three pragmatic principles with Git:
    - Commit often
    - Pull often
    - Push often
- Merge resolution is something important to learn