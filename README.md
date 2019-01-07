# WMProducts

## Information about Project Structure

### Architecture
* Using DotNet Core 2.1 as the back-end for the API
* Using Aurelia (and the Aurelia CLI) for the front-end. Documentation for Aurelia can be found here: [https://aurelia.io/ ]
* Database will be done in PostgreSQL: an open-source object-relational database management system. Documentation for PostgreSQL can be found here: [https://www.postgresql.org/], but it is very similar to MSSQL with few syntactic differences.

### Deployment and Hosting
* We are using AWS services for deployment and hosting
* API and Front-end will be hosted on AWS Elastic Beanstalk (credentials will be given to you via email, this is a public repo so no passwords, etc. should be put on here)
* We will be using AWS S3 for storage and RDS to host our database

### Software
* using Microsoft Visual Studio Community Edition 2017 for back-end
* using Microsoft Visual Studio Code 2017 for front-end
* currently using a trial version of JetBrains DataGrip for database, but a free alternative is DBeaver
* docker to aid in front-end deploys (credentials will be given to you via email, this is a public repo so no passwords, etc. should be put on here)

## To Run Project

### Back-end
* Open `/dotnet/wmproducts.webapi/wmproducts.webapi.sln` in Microsoft Visual Studio, restore Nuget packages and run as normal

### Front-end
Navigate to `/web` folder, right-click and open with Microsoft Visual Studio Code. In the Nav-bar on top of the application, select `View` and then `Integrated Terminal`. In this terminal, type:

```npm install```

Let this complete.
Once this is complete, type the following into the terminal:

```au run --watch```

Once the terminal says "Succeeded" the application can be accessed at [http://localhost:8080]

## Deployment Process

### Back-end
* Open `/dotnet/wmproducts.webapi/` folder in Microsoft Visual Code and once again open the `Integrated Terminal`. Run the command:

```dotnet publish -o site```

* Once this is completed, navigate to the newly created `site` folder (note to delete previous `site` folder before this step. Select everything within this file and send it to a zipped folder.

* Locate the file `aws-windows-deployment-manifest.json` and ensure that the `appBundle` name specified matches the name of the zipped file created in the previous step.

* Select the zipped file and the `aws-windows-deployment-manifest.json` and zip this file together (yes, a zipped file in the zipped file).

* Navigate to the AWS Elastic Beanstalk portal and select `Deploy and Upload`, then upload the zipped file and version the upload appropriately

### Front-end

* Sign in to Docker on your pc
* Open the command terminal 
* navigate to where the repo is in your pc and then `/web`
* Open `/web` in Microsoft Visual Code as well and run the the following command in the `Integrated Terminal`

```au build```

* Once this has completed, ensure that a `/web/dist` folder exists
* In your command terminal, run the command:

```docker build -t {myname}b/dockeraurelia:wmprodv{versionnumber} .``` (the dot at the end is very important)

* Next run 

```docker push {myname}b/dockeraurelia:wmprodv{versionnumber}```

* From here you should see the new docker image reflected in DockerHub
* To test this, run the command:

```docker run -d --rm -p 80:80 --name wmprodv{versionnumber} {myname}b/dockeraurelia:wmprodv{versionnumber}```

* I haven't figured out anything else from here, still working on it.
