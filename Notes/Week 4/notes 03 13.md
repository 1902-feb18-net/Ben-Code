# Notes 03/13/2019

## Design of something
- Source repo -> Developers, Developers -> Source repo
- Keep copy of compiled version of the repo on hand for sudden changes
- To do this, dev sents request to IT, who amkes the package repo
- Use of a dev server provides backup and a master source that should always work (it's a "source of truth")
    - It's like an app service, and doesn't actually run code

## DevOps
- An extension of Agile values to deployment + maintenance all the way to practice
- Using automation using params agreed upon by dev ops stakeholders to deploy frequently and with quality via automated checks
- Peoplel, process, product
- Stages:
    1. **Continuous integration (CI)**
            - very frequently, each dev's code is integrated with the others
            - code should buidl/comopile
            - tests should pass
            - static analysisi
        - Automated pipeline
            - To fetch latest role from GitHub
            - Fetch dependencies
            - Build code (dotnet build)
            - Run tests
            - Static analysis (sonar cloud)
            - package the code (dotnet publish)
            - Deploy to Azure
            - App source
    2. **Continuous Delivery (CD)**
        - Automated deployment all the way to production server with some manuel approvals in production
- **Sonar Queue**
    - Software for static analysis
        - Implicitly refers to code
        - Analyze code without actually running it
        - Finds problems, security flaws, and bad practices
    - SonarQube is an open-source platform developed by SonarSource for continuous inspection of code quality to perform automatic reviews with static analysis of code to detect bugs, code smells, a nd security vulnerabilities.
    - Azure DevOps uses SonarQube (SonarCloud) -> app(VM) (App Service)

MSYS_NO_PATHCONV=1 dotnet sonarscanner begin /k:"mages1902project1" /o:"impstar-github" /d:sonar.host.url="https//sonarcloud.io" /d:sonar.login="65fd005b4941294ffe126f19223905b95966df29"
