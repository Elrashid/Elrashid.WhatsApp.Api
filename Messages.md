# WhatsApp Business Platform > Cloud API > Reference

## Messages

Use the `/PHONE_NUMBER_ID/messages` endpoint to send text, media, contacts, location, and interactive messages, as well as message templates to your customers. Learn more about the messages you can send.

**Endpoint** | **Authentication**
--- | ---
`/PHONE_NUMBER_ID/messages` | (See Get Phone Number ID)

Developers can authenticate their API calls with the access token generated in the App Dashboard > WhatsApp > API Setup.

Solution Partners must authenticate themselves with an access token with the `whatsapp_business_messaging` permission.

Messages are identified by a unique ID (WAMID). You can track message status in the Webhooks through its WAMID. You could also mark an incoming message as read through messages endpoint. This WAMID can have a maximum length of up to 128 characters.

With the Cloud API, there is no longer a way to explicitly check if a phone number has a WhatsApp ID. To send someone a message using the Cloud API, just send it directly to the customer's phone number � after they have opted-in. See Reference, Messages for examples.

### Message Object

To send a message, you must first assemble a message object with the content you want to send. These are the parameters used in a message object:

**Name** | **Description**
--- | ---
`audio` | **object**<br>Required when type=`audio`.<br>A media object containing audio.
`biz_opaque_callback_data` | **string**<br>Optional.<br>An arbitrary string, useful for tracking. For example, you could pass the message template ID in this field to track your customer's journey starting from the first message you send. You could then track the ROI of different message template types to determine the most effective one. Any app subscribed to the messages webhook field on the WhatsApp Business Account can get this string, as it is included in statuses object within webhook payloads. Cloud API does not process this field, it just returns it as part of sent/delivered/read message webhooks. Maximum 512 characters. Cloud API only.
`contacts` | **object**<br>Required when type=`contacts`.<br>A contacts object.
`context` | **object**<br>Required if replying to any message in the conversation.<br>An object containing the ID of a previous message you are replying to. For example: `{"message_id":"MESSAGE_ID"}` Cloud API only.
`document` | **object**<br>Required when type=`document`.<br>A media object containing a document.
`hsm` | **object**<br>Contains an hsm object. This option was deprecated with v2.39 of the On-Premises API. Use the template object instead. On-Premises API only.
`image` | **object**<br>Required when type=`image`.<br>A media object containing an image.
`interactive` | **object**<br>Required when type=`interactive`.<br>An interactive object. The components of each interactive object generally follow a consistent pattern: header, body, footer, and action.
`location` | **object**<br>Required when type=`location`.<br>A location object.
`messaging_product` | **string**<br>Required.<br>Messaging service used for the request. Use `whatsapp`. Cloud API only.
`preview_url` | **boolean**<br>Required if type=`text`.<br>Allows for URL previews in text messages � See the Sending URLs in Text Messages. This field is optional if not including a URL in your message. Values: false (default), true. On-Premises API only. Cloud API users can use the same functionality with the `preview_url` field inside a text object.
`recipient_type` | **string**<br>Optional.<br>Currently, you can only send messages to individuals. Set this as `individual`. Default: `individual`.
`status` | **string**<br>A message's status. You can use this field to mark a message as read. See the following guides for information:<br>- Cloud API: Mark Messages as Read<br>- On-Premises API: Mark Messages as Read
`sticker` | **object**<br>Required when type=`sticker`.<br>A media object containing a sticker. Cloud API: Static and animated third-party outbound stickers are supported in addition to all types of inbound stickers. A static sticker needs to be 512x512 pixels and cannot exceed 100 KB. An animated sticker must be 512x512 pixels and cannot exceed 500 KB. On-Premises API: Only static third-party outbound stickers are supported in addition to all types of inbound stickers. A static sticker needs to be 512x512 pixels and cannot exceed 100 KB. Animated stickers are not supported.
`template` | **object**<br>Required when type=`template`.<br>A template object.
`text` | **object**<br>Required for text messages.<br>A text object.
`to` | **string**<br>Required.<br>WhatsApp ID or phone number of the customer you want to send a message to. See Phone Number Formats. If needed, On-Premises API users can get this number by calling the contacts endpoint.
`type` | **string**<br>Optional.<br>The type of message you want to send. If omitted, defaults to `text`.

The following objects are nested inside the message object:

#### Text Object
**Name** | **Description**
--- | ---
`body` | **string**<br>Required for text messages.<br>The text of the text message which can contain URLs which begin with `http://` or `https://` and formatting. See available formatting options here. If you include URLs in your text and want to include a preview box in text messages (`preview_url`: true), make sure the URL starts with `http://` or `https://` � `https://` URLs are preferred. You must include a hostname, since IP addresses will not be matched. Maximum length: 4096 characters.
`preview_url` | **boolean**<br>Optional. Cloud API only.<br>Set to true to have the WhatsApp Messenger and WhatsApp Business apps attempt to render a link preview of any URL in the body text string. URLs must begin with `http://` or `https://`. If multiple URLs are in the body text string, only the first URL will be rendered. If `preview_url` is omitted, or if unable to retrieve a preview, a clickable link will be rendered instead. On-Premises API users, use `preview_url` in the top-level message payload instead. See Parameters.

#### Media Object
See Get Media ID for information on how to get the ID of your media object. For information about supported media types for Cloud API, see Supported Media Types.

**Name** | **Description**
--- | ---
`id` | **string**<br>Required when type is audio, document, image, sticker, or video and you are not using a link. The media object ID. Do not use this field when message type is set to text.
`link` | **string**<br>Required when type is audio, document, image, sticker, or video and you are not using an uploaded media ID (i.e. you are hosting the media asset on your public server). The protocol and URL of the media to be sent. Use only with HTTP/HTTPS URLs. Do not use this field when message type is set to text. Cloud API users only: See Media HTTP Caching if you would like us to cache the media asset for future messages. When we request the media asset from your server you must indicate the media's MIME type by including the Content-Type HTTP header. For example: `Content-Type: video/mp4`. See Supported Media Types for a list of supported media and their MIME types.
`caption` | **string**<br>Optional.<br>Media asset caption. Do not use with audio or sticker media. On-Premises API users: For v2.41.2 or newer, this field is is limited to 1024 characters. Captions are currently not supported for document media.
`filename` | **string**<br>Optional.<br>Describes the filename for the specific document. Use only with document media. The extension of the filename will specify what format the document is displayed as in WhatsApp.
`provider` | **string**<br>Optional. On-Premises API only. This path is optionally used with a link when the HTTP/HTTPS link is not directly accessible and requires additional configurations like a bearer token. For information on configuring providers, see the Media Providers documentation.

#### Template Object
Conversation-based pricing has changed. See Pricing to learn how our new conversation-based pricing model works.

In addition, visibility of `metric_types` have changed effective July 1, 2023. Please see the Conversation Analytics table for more details.

**Name** | **Description**
--- | ---
`name` | **Required.** Name of the template.
`language` | **object**<br>Required. Contains a language object. Specifies the language the template may be rendered in. The language object can contain the following fields: `policy` - Required. The language policy the message should follow. The only supported option is `deterministic`. See Language Policy Options. `code` - Required. The code of the language or locale to use. Accepts both language and language_locale formats (e.g., en and en_US). For all codes, see Supported Languages.
`components` | **array of objects**<br>Optional. Array of components objects containing the parameters of the message.


`namespace` | Optional. Only used for On-Premises API. Namespace of the template.

The following objects are nested inside the template object:

#### Button Object
**Name** | **Description**
--- | ---
`type` | **string**<br>Required. Indicates the type of parameter for the button.
`payload` | Required for quick_reply buttons.<br>Developer-defined payload that is returned when the button is clicked in addition to the display text on the button. See Callback from a Quick Reply Button Click for an example.
`text` | Required for URL buttons.<br>Developer-provided suffix that is appended to the predefined prefix URL in the template.

#### Components Object
**Name** | **Description**
--- | ---
`type` | **string**<br>Required. Describes the component type. Example of a components object with an array of parameters object nested inside: 
```
"components": [{
  "type": "body",
  "parameters": [{
               "type": "text",
               "text": "name"
           },
           {
           "type": "text",
           "text": "Hi there"
           }]
     }]
```
`sub_type` | **string**<br>Required when type=`button`. Not used for the other types. Type of button to create.
`parameters` | **array of objects**<br>Required when type=`button`. Array of parameter objects with the content of the message. For components of type=`button`, see the button parameter object.
`index` | **Required when type=`button`. Not used for the other types.** Position index of the button. You can have up to 10 buttons using index values of 0 to 9.

#### Currency Object
**Name** | **Description**
--- | ---
`fallback_value` | **Required.** Default text if localization fails.
`code` | **Required.** Currency code as defined in ISO 4217.
`amount_1000` | **Required.** Amount multiplied by 1000.

#### Date_Time Object
**Name** | **Description**
--- | ---
`fallback_value` | **Required.** Default text. For Cloud API, we always use the fallback value, and we do not attempt to localize using other optional fields.

#### Parameter Object
**Name** | **Description**
--- | ---
`type` | **string**<br>Required. Describes the parameter type. Supported values: `currency`, `date_time`, `document`, `image`, `text`, `video`. For text-based templates, the only supported parameter types are currency, date_time, and text.
`text` | **string**<br>Required when type=`text`. The message�s text. Character limit varies based on the following included component type. For the header component type: 60 characters. For the body component type: 1024 characters if other component types are included. 32768 characters if body is the only component type included.
`currency` | **object**<br>Required when type=`currency`. A currency object.
`date_time` | **object**<br>Required when type=`date_time`. A date_time object.
`image` | **object**<br>Required when type=`image`. A media object of type image. Captions not supported when used in a media template.
`document` | **object**<br>Required when type=`document`. A media object of type document. Only PDF documents are supported for media-based message templates. Captions not supported when used in a media template.
`video` | **object**<br>Required when type=`video`. A media object of type video. Captions not supported when used in a media template.

#### Reaction Object
**Name** | **Description**
--- | ---
`message_id` | **string**<br>Required. The WhatsApp Message ID (wamid) of the message on which the reaction should appear. The reaction will not be sent if: The message is older than 30 days. The message is a reaction message. The message has been deleted. If the ID is of a message that has been deleted, the message will not be delivered.
`emoji` | **string**<br>Required. Emoji to appear on the message. All emojis supported by Android and iOS devices are supported. Rendered-emojis are supported. If using emoji unicode values, values must be Java- or JavaScript-escape encoded. Only one emoji can be sent in a reaction message. Use an empty string to remove a previously sent emoji.

## Examples

### Text Messages
```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM_PHONE_NUMBER_ID/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "recipient_type": "individual",
  "to": "PHONE_NUMBER",
  "type": "text",
  "text": {
    "preview_url": false,
    "body": "MESSAGE_CONTENT"
  }
}'
```

### Reaction Messages
```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM_PHONE_NUMBER_ID/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "recipient_type": "individual",
  "to": "PHONE_NUMBER",
  "type": "reaction",
  "reaction": {
    "message_id": "wamid.HBgLM...",
    "emoji": "\uD83D\uDE00"
  }
}'
```

### Media Messages
```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM-PHONE-NUMBER-ID/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "recipient_type": "individual",
  "to": "PHONE-NUMBER",
  "type": "image",
  "image": {
    "id" : "MEDIA-OBJECT-ID"
  }
}'
```

### Location Messages
```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM_PHONE_NUMBER_ID/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "to": "PHONE_NUMBER",
  "type": "location",
  "location": {
    "longitude": LONG_NUMBER,
    "latitude": LAT_NUMBER,
    "name": LOCATION_NAME,
    "address": LOCATION_ADDRESS
  }
}'
```

### Contact Messages
```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM_PHONE_NUMBER_ID/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "to": "PHONE_NUMBER",
  "type": "contacts",
  "contacts": [{
      "addresses": [{
          "street": "STREET",
          "city": "CITY",
          "state": "STATE",
          "zip": "ZIP",
          "country": "COUNTRY",
          "country_code": "COUNTRY_CODE",
          "type": "HOME"
        },
        {
          "street": "STREET",
          "city": "CITY",
          "state": "STATE",
          "zip": "ZIP",
          "country": "COUNTRY",
          "country_code": "COUNTRY_CODE",
          "type": "WORK"
        }],
      "birthday": "YEAR_MONTH_DAY",
      "emails": [{
          "email": "EMAIL",
          "type": "WORK"
        },
        {
          "email": "EMAIL",
          "type": "HOME"
        }],
      "name": {
        "formatted_name": "NAME",
        "first_name": "FIRST_NAME",
        "last_name": "LAST_NAME",
        "middle_name": "MIDDLE_NAME",
        "suffix": "SUFFIX",
        "prefix": "PREFIX"
      },
      "org": {
        "company": "COMPANY",
        "department": "DEPARTMENT",
        "title": "TITLE"
      },
      "phones": [{
          "phone": "PHONE_NUMBER",
          "type": "HOME"
        },
        {
          "phone": "PHONE_NUMBER",
          "type": "WORK",
          "wa_id": "PHONE_OR_WA_ID"
        }],
      "urls": [{
          "url": "URL",
          "type": "WORK"
        },
        {
          "url": "URL",
          "type": "HOME"
        }]
    }]
}'
```

### Interactive Messages

#### Single-Product Messages
```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM_PHONE_NUMBER/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "recipient_type": "individual",
  "to": "PHONE_NUMBER",
  "type": "interactive",
  "interactive": {
    "type": "product",
    "body": {
      "text": "optional body text"
    },
    "footer": {
      "text": "optional footer text"
    },
    "action": {
      "catalog_id": "CATALOG_ID",
      "product_retailer_id": "ID_TEST_ITEM_1"
    }
  }
}'
```

#### Multi-Product Messages
```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM_PHONE_NUMBER/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content

-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "recipient_type": "individual",
  "to": "PHONE_NUMBER",
  "type": "interactive",
  "interactive": {
    "type": "product_list",
    "header": {
      "type": "text",
      "text": "header-content"
    },
    "body": {
      "text": "body-content"
    },
    "footer": {
      "text": "footer-content"
    },
    "action": {
      "catalog_id": "CATALOG_ID",
      "sections": [
        {
          "title": "section-title",
          "product_items": [
            { "product_retailer_id": "product-SKU-in-catalog" },
            { "product_retailer_id": "product-SKU-in-catalog" }
          ]
        },
        {
          "title": "section-title",
          "product_items": [
            { "product_retailer_id": "product-SKU-in-catalog" },
            { "product_retailer_id": "product-SKU-in-catalog" }
          ]
        }
      ]
    }
  }
}'
```

#### Catalog Messages
```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM_PHONE_NUMBER/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "recipient_type": "individual",
  "to": "PHONE_NUMBER",
  "type": "interactive",
  "interactive" : {
    "type" : "catalog_message",
    "body" : {
      "text": "Thanks for your order! Tell us what address you�d like this order delivered to."
    },
    "action": {
      "name": "catalog_message",
      "parameters": { 
        "thumbnail_product_retailer_id": "<Product-retailer-id>"
      }
    }
  }
}'
```

#### Flows Messages
```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM_PHONE_NUMBER/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "recipient_type": "individual",
  "to": "PHONE_NUMBER",
  "type": "interactive",
  "interactive" : {
    "type": "flow",
    "header": {
      "type": "text",
      "text": "Flow message header"
    },
    "body": {
      "text": "Flow message body"
    },
    "footer": {
      "text": "Flow message footer"
    },
    "action": {
      "name": "flow",
      "parameters": {
        "flow_message_version": "3",
        "flow_token": "AQAAAAACS5FpgQ_cAAAAAD0QI3s",
        "flow_id": "<FLOW_ID>",
        "flow_cta": "Book!",
        "flow_action": "navigate",
        "flow_action_payload": {
          "screen": "<SCREEN_ID>",
          "data": {
            "user_name": "name",
            "user_age": 25
          }
        }
      }
    }
  }
}'
```

#### List Messages
```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM_PHONE_NUMBER_ID/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "recipient_type": "individual",
  "to": "PHONE_NUMBER",
  "type": "interactive",
  "interactive": {
    "type": "list",
    "header": {
      "type": "text",
      "text": "HEADER_TEXT"
    },
    "body": {
      "text": "BODY_TEXT"
    },
    "footer": {
      "text": "FOOTER_TEXT"
    },
    "action": {
      "button": "BUTTON_TEXT",
      "sections": [
        {
          "title": "SECTION_1_TITLE",
          "rows": [
            {
              "id": "SECTION_1_ROW_1_ID",
              "title": "SECTION_1_ROW_1_TITLE",
              "description": "SECTION_1_ROW_1_DESCRIPTION"
            },
            {
              "id": "SECTION_1_ROW_2_ID",
              "title": "SECTION_1_ROW_2_TITLE",
              "description": "SECTION_1_ROW_2_DESCRIPTION"
            }
          ]
        },
        {
          "title": "SECTION_2_TITLE",
          "rows": [
            {
              "id": "SECTION_2_ROW_1_ID",
              "title": "SECTION_2_ROW_1_TITLE",
              "description": "SECTION_2_ROW_1_DESCRIPTION"
            },
            {
              "id": "SECTION_2_ROW_2_ID",
              "title": "SECTION_2_ROW_2_TITLE",
              "description": "SECTION_2_ROW_2_DESCRIPTION"
            }
          ]
        }
      ]
    }
  }
}'
```

#### Reply Button
```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM_PHONE_NUMBER_ID/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "recipient_type": "individual",
  "to": "PHONE_NUMBER",
  "type": "interactive",
  "interactive": {
    "type": "button",
    "body": {
      "text": "BUTTON_TEXT"
    },
    "action": {
      "buttons": [
        {
          "type": "reply",
          "reply": {
            "id": "UNIQUE_BUTTON_ID_1",
            "title": "BUTTON_TITLE_1"
          }
        },
        {
          "type": "reply",
          "reply": {
            "id": "UNIQUE_BUTTON_ID_2",
            "title": "BUTTON_TITLE_2"
          }
        }
      ]
    }
  }
}'
```

#### Template Messages
Conversation-based pricing has changed. See Pricing to learn how our new conversation-based pricing model works.

In addition, visibility of `metric_types` have changed effective July 1, 2023. Please see the Conversation Analytics table for more details.

```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM_PHONE_NUMBER_ID/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "recipient_type": "individual",
  "to": "PHONE_NUMBER",
  "type": "template",
  "template": {
    "name": "TEMPLATE_NAME",
    "language": {
      "code": "LANGUAGE_AND_LOCALE_CODE"
    },
    "components": [
      {
        "type": "header",
        "parameters": [
          {
            "type": "image",
            "image": {
              "link": "http(s)://URL"
            }
          }
        ]
      },
      {
        "type": "body",
        "parameters": [
          {
            "type": "text",
            "text": "TEXT_STRING"
          },
          {
            "type": "currency",
            "currency": {
              "fallback_value": "VALUE",
              "code": "USD",
              "amount_1000": NUMBER
            }
          },
          {
            "type": "date_time",
            "date_time": {
              "fallback_value": "MONTH DAY, YEAR"
            }
          }
        ]
      },
      {
        "type": "button",
        "sub_type": "quick_reply",
        "index": "0",
        "parameters": [
          {
            "type": "payload",
            "payload": "PAYLOAD"
          }
        ]
      },
      {
        "type": "button",
        "sub_type": "quick_reply",
        "index": "1",
        "parameters": [
          {
            "type": "payload",
            "payload": "PAYLOAD"
          }
        ]
      }
    ]
  }
}'
```

### Reply To Message
```bash
curl -X POST \
'https://graph.facebook.com/v20.0/FROM_PHONE_NUMBER/messages' \
-H 'Authorization: Bearer ACCESS_TOKEN' \
-H 'Content-Type: application/json' \
-d '{
  "messaging_product": "whatsapp",
  "context": {
     "message_id": "MESSAGE_ID"
  },
  "to": "PHONE_NUMBER",
  "type": "text",
  "text": {
    "preview_url": false,
    "body": "your-text-message-content"
  }
}'
```

## Successful Response
```json
{
  "messaging_product": "whatsapp",
  "contacts": [
    {
      "input": "16505555555",
      "wa_id": "16505555555"
    }
  ],
  "messages": [
    {
      "id": "wamid.HBgLMTY1MDUwNzY1MjAVAgARGBI5QTNDQTVCM0Q0Q0Q2RTY3RTcA"
    }
  ]
}
```

Applies to businesses in Brazil, Colombia, and Singapore, starting September 12, 2023. Applies to all businesses starting October 12, 2023.

Messages will have one of the following statuses which will be returned in each of the messages objects:

- `"message_status":"accepted"`: means the message was sent to the intended recipient.
- `"message_status":"held_for_quality_assessment"`: means the message

 send was delayed until quality can be validated and it will either be sent or dropped at this point.

```json
{
  "messaging_product": "whatsapp",
  "contacts": [
    {
      "input": "16505555555",
      "wa_id": "16505555555"
    }
  ],
  "messages": [
    {
      "id": "wamid.HBgLMTY1MDUwNzY1MjAVAgARGBI5QTNDQTVCM0Q0Q0Q2RTY3RTcA",
      "message_status": "accepted"
    }
  ]
}
```


