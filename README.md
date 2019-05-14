# blazorwitheventstore
Blazor Pre4 + EventStore

EventStore Persistent Subscriptions
For example: Three consumer wait for event. If a subscribed consumer catch an event, other consumers wait another events.
```csharp
connection.ConnectToPersistentSubscriptionAsync("test-stream", "agroup", EventAppeared, SubscriptionDropped, userCredentials, 10, true);
```
![alt text](https://codeopinion.com/wp-content/uploads/2016/02/queue.png)

EventStore Catch Up Subscriptions
For example: Three consumer wait for event. All subscribed consumer catch an event.
```csharp
connection.SubscribeToStreamAsync("test-stream", true, EventAppeared, SubscriptionDropped, userCredentials);
```
