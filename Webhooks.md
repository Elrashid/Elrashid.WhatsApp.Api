### Webhooks Notification Payload Reference

Webhooks are triggered when a customer performs an action or the status of a message sent by a business changes. The following outlines when and how webhooks notifications are sent, including the structure and components of the notification payload.

#### Customer Actions that Trigger Webhooks:
- Sends a text message to the business.
- Sends media (image, video, audio, document, sticker) to the business.
- Sends contact or location information to the business.
- Clicks a reply button or call-to-action button on an ad.
- Clicks an item on a business' list.
- Updates their profile information.
- Requests information about a specific product.
- Orders products from the business.

#### Message Status Changes that Trigger Webhooks:
- Delivered
- Read
- Sent

### Notification Payload Object

The notification payload is a nested JSON structure with arrays and objects containing details about the change. Here's an example payload:

```json
{
  "object": "whatsapp_business_account",
  "entry": [{
    "id": "WHATSAPP-BUSINESS-ACCOUNT-ID",
    "changes": [{
      "value": {
        "messaging_product": "whatsapp",
        "metadata": {
          "display_phone_number": "PHONE-NUMBER",
          "phone_number_id": "PHONE-NUMBER-ID"
        },
        "contacts": [{...}],
        "errors": [{...}],
        "messages": [{...}],
        "statuses": [{...}]
      },
      "field": "messages"
    }]
  }]
}
```

### Structure Details:

#### Object
- **Type**: string
- **Description**: The webhook subscribed to, always `whatsapp_business_account`.

#### Entry
- **Type**: array of objects
- **Description**: Contains the entries of webhook notifications.
  - **ID**: string, the WhatsApp Business Account ID.
  - **Changes**: array of objects
    - **Value**: object containing the details of the change.
    - **Field**: string, notification type (`messages`).

#### Value Object
Contains details about the change that triggered the webhook.

- **Contacts**: array of objects
  - **wa_id**: string, the customer's WhatsApp ID.
  - **Profile**: object
    - **Name**: string, the customer's name.

- **Errors**: array of objects describing errors.
  - **Code**: integer, error code.
  - **Title**: string, error code title.
  - **Message**: string, error code message.
  - **Error_Data**: object with additional error details.

- **Messaging_Product**: string, always `whatsapp`.

- **Messages**: array of objects
  - **Type**: various types (audio, button, document, text, image, interactive, order, sticker, system, video).
  - **Context**: object, included when a user interacts with a message.
  - **Document**: object, included when the type is `document`.
  - **Errors**: array of objects, error details.
  - **From**: string, the customer's WhatsApp ID.
  - **Id**: string, message ID.
  - **Identity**: object, customer identity changes.
  - **Image**: object, included when the type is `image`.
  - **Interactive**: object, when a customer interacts with a message.
  - **Order**: object, when a customer places an order.
  - **Referral**: object, when a customer clicks an ad leading to WhatsApp.
  - **Sticker**: object, when the type is `sticker`.
  - **System**: object, when the type is `system`.
  - **Text**: object, when the type is `text`.
  - **Timestamp**: string, Unix timestamp.
  - **Type**: string, type of message.

- **Metadata**: object
  - **Display_Phone_Number**: string, the displayed phone number.
  - **Phone_Number_ID**: string, ID for the phone number.

- **Statuses**: array of objects, message status changes.
  - **Biz_Opaque_Callback_Data**: string, arbitrary string included in sent message.
  - **Conversation**: object, conversation details.
    - **Id**: string, conversation ID.
    - **Origin**: object, conversation category.
    - **Type**: string, conversation category type.
    - **Expiration_Timestamp**: string, conversation expiration date.
  - **Errors**: array of objects, error details.
  - **Id**: string, message ID.
  - **Pricing**: object, pricing information.
    - **Billable**: boolean, indicates if the conversation is billable.
    - **Category**: string, conversation category.
    - **Pricing_Model**: string, type of pricing model.
  - **Recipient_ID**: string, customer's WhatsApp ID.
  - **Status**: string, status of the message (delivered, read, sent).
  - **Timestamp**: string, Unix timestamp of the status.

### Learn More
- Visit the WhatsApp Business Management API Webhooks documentation for detailed setup instructions.
- Check out Webhook Notification Payload Examples for more practical uses.