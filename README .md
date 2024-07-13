# WhatsApp Business API Integration Project

This project provides a .NET implementation for integrating with the WhatsApp Business API. It includes components for sending messages, handling webhooks, and managing various message types supported by the WhatsApp Business Platform.

## Table of Contents

1. [Project Structure](#project-structure)
2. [Features](#features)
3. [Getting Started](#getting-started)
4. [Usage Examples](#usage-examples)
5. [Webhook Handling](#webhook-handling)
6. [Contributing](#contributing)
7. [License](#license)
8. [Official Documentation](#official-documentation)

## Project Structure

The project consists of two main namespaces:

1. `Elrashid.WhatsApp.Messages`: Contains classes for sending messages through the WhatsApp Business API.
2. `Elrashid.WhatsApp.Webhooks`: Contains classes for handling incoming webhook notifications from WhatsApp.

## Features

- Send various types of messages (text, media, interactive, template, etc.)
- Handle incoming webhook notifications
- Support for all message types provided by the WhatsApp Business API
- Strongly-typed C# classes for easy integration and type safety

## Getting Started

1. Clone the repository
2. Install the required NuGet packages:
   - Newtonsoft.Json
   - System.Net.Http
3. Set up your WhatsApp Business Account and obtain the necessary credentials (Phone Number ID, Access Token)

## Usage Examples

### Sending a Text Message

```csharp
var client = new WAppMsgApiClient("https://graph.facebook.com/v20.0", "YOUR_PHONE_NUMBER_ID", "YOUR_ACCESS_TOKEN");

var messageRequest = new WAppMsgApiClient.WAppMsgRequest(
    to: "RECIPIENT_PHONE_NUMBER",
    type: WAppMsgApiClient.WAppMsgRequest.WAppMsgType.Text
);

messageRequest.Text = new WAppMsgApiClient.WAppMsgRequest.WAppMsgTextContent("Hello, World!");

var response = await client.SendMessageAsync(messageRequest);
```

### Sending an Interactive Message

```csharp
var client = new WAppMsgApiClient("https://graph.facebook.com/v20.0", "YOUR_PHONE_NUMBER_ID", "YOUR_ACCESS_TOKEN");

var messageRequest = new WAppMsgApiClient.WAppMsgRequest(
    to: "RECIPIENT_PHONE_NUMBER",
    type: WAppMsgApiClient.WAppMsgRequest.WAppMsgType.Interactive
);

messageRequest.Interactive = new WAppMsgApiClient.WAppMsgRequest.WAppMsgInteractiveContent
{
    Type = new WAppMsgApiClient.WAppMsgRequest.WAppMsgInteractiveContent.WAppMsgInteractiveType
    {
        ButtonReply = new WAppMsgApiClient.WAppMsgRequest.WAppMsgInteractiveContent.WAppMsgInteractiveType.WAppMsgButtonReply
        {
            Id = "unique_button_id",
            Title = "Click me!"
        }
    }
};

var response = await client.SendMessageAsync(messageRequest);
```

## Webhook Handling

To handle incoming webhook notifications, you can use the `WAppHokWebhookNotification` class:

```csharp
public void HandleWebhook(string jsonPayload)
{
    var notification = JsonConvert.DeserializeObject<WAppHokWebhookNotification>(jsonPayload);

    foreach (var entry in notification.Entries)
    {
        foreach (var change in entry.Changes)
        {
            if (change.Field == "messages")
            {
                foreach (var message in change.Value.Messages)
                {
                    // Process the message based on its type
                    switch (message.Type)
                    {
                        case WAppHokWebhookNotification.WAppHokEntry.WAppHokChange.WAppHokValue.WAppHokMessage.WAppHokMessageType.text:
                            Console.WriteLine($"Received text message: {message.Text.Body}");
                            break;
                        // Handle other message types...
                    }
                }
            }
        }
    }
}
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License.

## Official Documentation

This project is based on the official WhatsApp Business API documentation. For the most up-to-date and detailed information, please refer to the following resources:

- [WhatsApp Business API Reference](https://developers.facebook.com/docs/whatsapp/cloud-api/reference)
- [Webhooks Documentation](https://developers.facebook.com/docs/whatsapp/cloud-api/webhooks/components#messages-object)
- [Messages Documentation](https://developers.facebook.com/docs/whatsapp/cloud-api/reference/messages#template-object)
- [Media Documentation](https://developers.facebook.com/docs/whatsapp/cloud-api/reference/media)

Please note that the WhatsApp Business API may undergo changes and updates. Always refer to the official documentation for the most current information and best practices.