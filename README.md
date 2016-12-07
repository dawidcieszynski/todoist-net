# Todoist.Net
A [Todoist v7 API](https://developer.todoist.com/) client for .NET.

## Installation

The library is available as a [Nuget package](https://www.nuget.org/packages/Todoist.Net/).
```
Install-Package Todoist.Net
```

## Get started

### Creating Todoist client

With token (preferred way):
```csharp
ITodoistClient client = new TodoistClient("API token");
```

With email and password:
```csharp
ITodoistClient client = await TodoistClient.LoginAsync("email", "password");
```

### Simple API calls
```csharp
// Get all projects.
var projects = await client.Projects.GetAsync();

// Adding a task with a note.
var taskId = await client.Items.AddAsync(new Item("New task"));
await client.Notes.AddToItemAsync(new Note("Task decription"), taskId);
```

### Transactions (Batching)
Batching: reading and writing of multiple resources can be done in a single HTTP request.

Add project, task and not in one request
```csharp
// These requests are queued and will be executed later.
var projectId = await transaction.Project.AddAsync(new Project("New project"));
var taskId = await transaction.Items.AddAsync(new Item("New task", projectId));
await transaction.Notes.AddToItemAsync(new Note("Task description"), taskId);

// Execute all the requests in the transaction in a single HTTP request.
await transaction.CommitAsync();

```

## Known issues
At the moment implemented all APIs except [Sharing](https://developer.todoist.com/?shell#sharing) and [Business](https://developer.todoist.com/?shell#business) because I don't have a Business account to test them.
