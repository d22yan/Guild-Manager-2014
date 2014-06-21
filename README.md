Guild Manager 2014
==================

Development Workflow
--------------------

Initial setup:

1. Install git and [SourceTree](http://www.sourcetreeapp.com/)
2. Clone repo to local directory
3. Open project with Unity
4. Try the game and make sure everything works

To begin with we need to brainstorm a list of issues/improvements.

Create issues here on Github (issue button on sidebar):

- Type can be set to bug or enhancement as appropriate. 
- Milestone should be set to the Project Demo Milestone I just created. 
- If you think of an issue/improvement that would be nice to have but out of scope for the Project Demo, create it without any Milestone for now.


General notes on collaboration:

- Before beginning work on an issue, assign it to yourself so nobody ends up working on the same thing as someone else.
- Only have 1 issue assigned to yourself at a time. Finish your current issue before starting work on another, so people who are free always have something to pick up. If nothing is available, play around with the app and try to think of another improvement you could make, and create an issue for that. Or send an email asking for help with finding work.
- Try not to change any code not related to what's described in the issue to minimize incompatible changes or repeated work. If you feel something else needs to be changed, add it as an issue first.
- Never commit directly to master. Create a new branch for each issue you work on, and commit only to that branch. 
- When you feel the issue is finished, push the branch to Github and open a Pull Request (it'll pop up as an option on top whenever you push a new branch) with a reference to the issue # in the title and/or description. This will send an email to notify everybody.
- Check your email often for new pull requests, and review them as soon as you can. Leave a comment on the PR saying that you'll be reviewing it, and then pull the issue branch and test out the changes in Unity. Make sure the issue is completed, and the changes did not break anything else.
- After you've reviewed an issue, merge it to master by clicking the merge button on the PR page. If there are conflicts, the person submitting the PR should try to resolve it or ask for help with the conflict resolution.
