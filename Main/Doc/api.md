CODESHARE  
===

API Documentation
---


### PROJECTS ###

#### PROJECT INFO EXAMPLE ####
    {
      "id": 1,
      "name": "A Project Name",
      "quickDescription": "A Project Quick Description",
      "description": "This is a description.",
      "logoUrl": null,
      "sourceUrl": "http://bdelnetdxw00.globant.com:1010",
      "creationDate": "\/Date(1412118533083-0300)\/"
    }

#### GET PROJECT ####

**Description**: 
Allow the user to get a specific project information

**Arguments**:
{id} the id of the project

**Returns**: ProjectInfo. Information about the project

**Definition**: GET https://api.codeshare.globant.com/v1/projects/{id}

**Example Request**: https://api.codeshare.globant.com/v1/projects/1

**Example Response**:

    {
      "id": 1,
      "name": "New Project",
      "quickDescription": "Quick Description",
      "description": "This is a description.",
      "logoUrl": "http://www.blogcdn.com/www.joystiq.com/media/2009/02/quake_3_arena_580px.jpg",
      "sourceUrl": "http://bdelnetdxw00.globant.com:1010",
      "creationDate": "\/Date(1412118533083-0300)\/"
    }

**Error Messages**:

404 If there is no project with the provided id

#### CREATE PROJECTS ####

**Description**:
Allow the user to create a new project

**Arguments**:
ProjectInfo. Only Name and Quick Description is required at this point.

**Returns**:
ProjectInfo with the new project Id

**Definition**:
POST https://api.codeshare.globant.com/v1/projects

**Example Request**:

    {
      "name": "A New Project",
      "quickDescription": "This is a quick description",
    }

**Example Response**:

    {
      "id": 2,
      "name": "Another New Project",
      "quickDescription": "This is a quick description",
      "description": null,
      "logoUrl": null,
      "sourceUrl": null,
      "creationDate": "\/Date(1414430046888-0300)\/"
    }

**Error Messages**:

400 If the a project with the same name already exists

#### GET LATEST PROJECTS ####

**Description**:
Get the latest projects according to CreationDate

**Arguments**:
{top} Optional parameter to indicate how many projects do you want. By default it will return the latest 10 projects

**Returns**:
An array of ProjectInfo

**Description**:
GET https://api.codeshare.globant.com/v1/projects/latest?top=x

**Example Request**:

https://api.codeshare.globant.com/v1/projects/latest?top=2

**Example Response**:

    [
      {
    "id": 4,
    "name": "Another New Project",
    "quickDescription": "This is a quick description",
    "description": null,
    "logoUrl": null,
    "sourceUrl": null,
    "creationDate": "\/Date(1414430046890-0300)\/"
      },
      {
    "id": 3,
    "name": "A New Project",
    "quickDescription": "This is a quick description",
    "description": null,
    "logoUrl": null,
    "sourceUrl": null,
    "creationDate": "\/Date(1414430013263-0300)\/"
      }
    ]

#### UPDATE  PROJECT ####

**Description**:
Update a specific project Quick Description, Description and or Logo URL

**Arguments**:
A ProjectInfo with the updated information

**Returns**:
A ProjectInfo with the updated information

**Definition**:
PUT https://api.codeshare.globant.com/v1/projects

**Example Request**:

      {
    	"id": 2,
    	"quickDescription": "This is an updated quick description",
    	"description": "new description",
    	"logoUrl": "http://img4.wikia.nocookie.net/__cb20091010095734/starcraft/images/7/7a/JimRaynor_SC2_Art1.jpg"
      }

**Example Response**:

    {
      "id": 5,
      "name": "test project",
      "quickDescription": "This is an updated quick description",
      "description": "new description",
      "logoUrl": "http://img4.wikia.nocookie.net/__cb20091010095734/starcraft/images/7/7a/JimRaynor_SC2_Art1.jpg",
      "sourceUrl": null,
      "creationDate": "\/Date(1414432707167-0300)\/"
    }

**Error Messages**:

403 If the user is not member of the project

### USERS ###

#### User Info Example ####

    {
      "id": 1,
      "userName": "GLOBANT\\mario.moreno",
      "nickName": "mario.moreno",
      "avatarUrl": "http://www.lesavatars.com/Smile/Quake-3-Arena/quake3_sarge.gif",
      "joinDate": "\/Date(1411134727387-0300)\/"
    }

#### CURRENT ####

**Description**:
Get the current UserInfo

**Arguments**:
None

**Returns**:
The UserInfo of the current user

**Definition**:
GET https://api.codeshare.globant.com/v1/users/current

**Example Request:**


**Example Response:**

    {
      "id": 1,
      "userName": "GLOBANT\\mario.moreno",
      "nickName": "mario.moreno",
      "avatarUrl": "http://www.lesavatars.com/Smile/Quake-3-Arena/quake3_sarge.gif",
      "joinDate": "\/Date(1411134727387-0300)\/"
    }

**Error Messages**:

401 if the user is not authenticated


#### CREATE USER ####

**Description**:
Create a new user

**Arguments**:
UserName and AvatarUrl

**Returns**:
The UserInfo of the created user

**Definition:**
POST https://api.codeshare.globant.com/v1/users

**Example Request:**

    {
      "userName": "GLOBANT\\samus.aran",
      "avatarUrl": "http://img3.wikia.nocookie.net/__cb20110403230142/metroid/images/f/fa/Samus_Aran.JPG"
    }


**Example Response:**

    {
      "id": 2,
      "userName": "globant\\samus.aran",
      "nickName": "samus.aran",
      "avatarUrl": "http://img3.wikia.nocookie.net/__cb20110403230142/metroid/images/f/fa/Samus_Aran.JPG",
      "joinDate": "\/Date(1414435820851-0300)\/"
    }

**Error Messages:**

#### UPDATE USER ####

**Description:**
Update the UserNickName and or AvatarUrl

**Arguments:**
UserNickName and AvatarUrl

**Returns:**
The UserInfo of the updated user

**Definition:**
PUT  https://api.codeshare.globant.com/v1/users

**Example Request:**

    {
      "nickName": "Mario Moreno",
      "avatarUrl": "http://lvlworld.com/avatar/default/visor.jpg"
    }

**Example Response:**

    {
      "id": 1,
      "userName": "GLOBANT\\mario.moreno",
      "nickName": "Mario Moreno",
      "avatarUrl": "http://lvlworld.com/avatar/default/visor.jpg",
      "joinDate": "\/Date(1411134727387-0300)\/"
    }

**Error Messages:**

#### SEARCH ####

#### Paged Project Info Example ####

    {
      "items": [
    	{
      		"id": 4,
      		"name": "New Project",
      		"quickDescription": "This is a quick description",
      		"description": null,
      		"logoUrl": null,
      		"sourceUrl": null,
      		"creationDate": "\/Date(1414430046890-0300)\/"
    	}
      ],
      "totalCount": 2
    }

**Description:**
Search by project name

**Arguments:**
Name=Some characters about how the project name starts
Page=The page number. 0 by default
PageSize=The page size. 10 by default

**Returns:**
PagedProjectInfo

**Definition:**

GET  https://api.codeshare.globant.com/v1/search?name={ProjectName}&page={Page}&pageSize={PageSize}

**Example Request:**

GET  https://api.codeshare.globant.com/v1/search?name=project&page=0&pageSize=10

**Example Response:**

    {
      "items": [
    	{
      		"id": 4,
      		"name": "Another New Project",
      		"quickDescription": "This is a quick description",
      		"description": null,
      		"logoUrl": null,
      		"sourceUrl": null,
      		"creationDate": "\/Date(1414430046890-0300)\/"
    	},
    	{
      		"id": 3,
      		"name": "A New Project",
      		"quickDescription": "This is a quick description",
      		"description": null,
      		"logoUrl": null,
      		"sourceUrl": null,
      		"creationDate": "\/Date(1414430013263-0300)\/"
    	}
      ],
      "totalCount": 2
    }

**Error Messages:**

ENTITIES

Project
ProjectFile
ProjectOpening
ProjectRelease
ProjectUser
ProjectUserRequest
ProjectUserRole
Tag
User

PROJECT
	int Id
	string Name
	string QuickDescription
	string Description
	string LogoUrl
	string SourceUrl
	DateTime CreationDate
	ICollection<User> Likes
	ICollection<User> Followers
	ProjectUser Creator
	ICollection<ProjectUser> Members
	ICollection<ProjectUserRequest> MemberRequests
	ICollection<ProjectOpening> Openings
	ICollection<Tag> Tags
	ICollection<ProjectReleases> Releases
	
ProjectInfo(Id, Name, QuickDescription, Description, LogoUrl, SourceUrl, CreationDate, LikesCount, FollowersCount, Like, Following)
{ProjectInfo} GET /projects/{id}
{ProjectInfo} POST /projects/
{ProjectInfo}
{ProjectInfo} PUT /projects/
{ProjectInfo} Name, QuickDescription, Description, LogoUrl, SourceUrl
POST /projects/{id}/like
POST /projects/{id}/follow
{ProjectUserInfo} GET /projects/{id}/creator
[{ProjectInfo}] GET /projects/latest?{top:int}
{ProjectUserInfo} GET /projects/{id}/members
{ProjectUserRequestInfo} GET /projects/{id}/memberrequests
POST /projects/{id}/memberrequests
{ProjectUserRequestInfo}
[{ProjectOpeningInfo}] GET /projects/{id}/openings?{top:int}
{ProjectOpeningInfo} POST /projects/{id}/openings
{ProjectOpeningInfo}
{TagInfo} GET /projects/{id}/tags?{top:int}
{[TagInfo}] POST /projects/{id}/tags
{TagInfo}
[{ProjectReleaseInfo}] GET /projects/{id}/releases
{ProjectReleaseInfo} POST /projects/{id}/releases
{ProjectReleaseInfo}
{string} GET /projects/{id}/releases/download (link to download the latest release)
{string} GET /projects/{id}/releases/{id}/download (link to download a specific release)

USER
	int Id
	string UserName
	string NickName
	string AvatarUrl
	DateTime JoinDate
	ICollection<Project> Following
	ICollection<Project> CreatorOf
	ICollection<Project> AdministratorOf
	ICollection<Project> ContributorFor

UserInfo (Id, UserName, NickName, AvatarUrl, JoinDate, FollowingCount, CreatorOfCount, AdministratorForCount, ContributorForCount)

{UserInfo} GET /users/current
{UserInfo} PUT /users/
{UserInfo} NickName, AvatarUrl
[{ProjectInfo}] GET /users/following
[{ProjectInfo}] GET /users/creatorof
[{ProjectInfo}] GET /users/administratorfor
[{ProjectInfo}] GET /users/contributorfor

SEARCH

[{ProjectInfo}] GET /projects/search?{query:string}&{top:int}
[{ProjectInfo}] GET /projects/advancedsearch?{query:string}&state=open&sort=-priority,created_at&{top:int}
[{ProjectOpeningInfo}] GET /projects/openings/search?{query:string}



