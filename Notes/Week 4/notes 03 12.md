# Notes 03/12/2019

## Software Devellopment Lifecycle (SDLC)
- Waterfall model
    - Gather requirements
    - Design
    - Build
    - Test
    - Deploy
    - Slow and not adaptable; can't be positive you're done with any one step, and requirements can change.  You can't go back to fix subpar elements, only march forwards.
    - Pros: enables more security for each step and also enables more accountability
- Iterative models
    - In contrast to Waterfall model
    - Enables more iteractions of development process
    - Spiral model
        - Multiple iterations of the Waterfall model, where you go through all the steps, make sure that this is what the client wants, and if it isn't go back through the steps
    - Big Bang model
        - Everything at once in one day (or a short amount of time)
        - Suitable for prototypes but that's basically it
    - **Agile** models
        - More a process than a model
        - We break project up into features/small pieces called user stories
        - We run user stories through stages of our development
        - *SCRUM*
            - A concrete model
            - User story: feature/bugfix
            - Scrum Board
            
| Backlog     | In progress | Testing     | Done        | Released    |
|-------------|-------------|-------------|-------------|-------------|
| -user story | -user story | -user story | -user story | -user story |
| -user story | -user story | -user story | -user story | -user story |
| -user story | -user story | -user story | -user story | -user story |

            - Scrum master (manages scrum board and organizes participants)
            - Sprint
                - Bite off chunk of project, break that down into tasks, then attempt to finish the sprint (usually in 2 - 6 weeks, but can give or take)
                - Sprint planning meetings happen at the beginning
                - Everyone involved in the project should be able to look at the project board
                - Daily standup
                    1.  What did you do that day/last day
                    2.  What do you do next
                    3.  Blocks to work
                - Sprint review
                    - At the end of the Sprint period, review amount of work done compared to amount of work planned
                    - Did they accomplish everything they set out to do?  More?  Less?  
                    - Helps judge work capacity (productive work hours/points available in the sprint)
                    - Velocity: each user story has estimated "effort" in points
                        - Uses Fibonacci sequence (1, 2, 3, 5, 8, 13, 21, etc.)
                        - Is the sum of effort points completed in the sprint
                    - Compare production and capacity
                - Backlog: All stories uncompleted in project
                - Strict schedule for completing preset ammount of work with reevaluation after each sprint
            - Stakeholder
                - Anyone with a stake in the project (anyone who cares about it)
                - Should be involved with the development process to the extent they want to be
        - *Kanban*
            - A lot of similarities with SCRUM
            - No sprints
            - More ambitious than SCRUM
            - Continuous planning and continuous reflection/reevaluation
            - Has "Kanban board"
                - Each column in the board has a maximum number of points it can contain
                - Makes real world constraint explicit and can help see problems before they occur
                - Attempts to limit max work in progress with continuous reevaluation
        - *CMMI*
            - Very process-heavy version of Agile
            - + security, accountability
        - Getting feedback from users is essential to Agile development; without that, it's just an imitation of Agile (fake Agile)
