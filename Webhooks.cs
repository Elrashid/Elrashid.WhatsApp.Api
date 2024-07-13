using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Elrashid.WhatsApp.Api.Webhooks
{
    public class WAppHokWebhookNotification
    {
        [JsonPropertyName("object")]
        public string? Object { get; set; } // The webhook type (e.g., "whatsapp_business_account")

        [JsonPropertyName("entry")]
        public List<WAppHokEntry>? Entries { get; set; } // List of entries
    }

    public class WAppHokEntry
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; } // WhatsApp Business Account ID

        [JsonPropertyName("changes")]
        public List<WAppHokChange>? Changes { get; set; } // List of changes
    }

    public class WAppHokChange
    {
        [JsonPropertyName("value")]
        public WAppHokValue? Value { get; set; } // Value object

        [JsonPropertyName("field")]
        public string? Field { get; set; } // Notification type (e.g., "messages")
    }

    public class WAppHokValue
    {
        [JsonPropertyName("messaging_product")]
        public string? MessagingProduct { get; set; } // Product used to send the message (always "whatsapp")

        [JsonPropertyName("metadata")]
        public WAppHokMetadata? Metadata { get; set; } // Metadata object

        [JsonPropertyName("contacts")]
        public List<WAppHokContact>? Contacts { get; set; } // List of contacts

        [JsonPropertyName("errors")]
        public List<WAppHokError>? Errors { get; set; } // List of errors

        [JsonPropertyName("messages")]
        public List<WAppHokMessage>? Messages { get; set; } // List of messages

        [JsonPropertyName("statuses")]
        public List<WAppHokStatus>? Statuses { get; set; } // List of statuses
    }

    public class WAppHokMetadata
    {
        [JsonPropertyName("display_phone_number")]
        public string? DisplayPhoneNumber { get; set; } // Display phone number

        [JsonPropertyName("phone_number_id")]
        public string? PhoneNumberId { get; set; } // Phone number ID
    }

    public class WAppHokContact
    {
        [JsonPropertyName("wa_id")]
        public string? WaId { get; set; } // Customer's WhatsApp ID

        [JsonPropertyName("profile")]
        public WAppHokProfile? Profile { get; set; } // Profile object
    }

    public class WAppHokProfile
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; } // Customer's name
    }

    public class WAppHokError
    {
        [JsonPropertyName("code")]
        public int? Code { get; set; } // Error code

        [JsonPropertyName("title")]
        public string? Title { get; set; } // Error title

        [JsonPropertyName("message")]
        public string? Message { get; set; } // Error message

        [JsonPropertyName("error_data")]
        public WAppHokErrorData? ErrorData { get; set; } // Error data object
    }

    public class WAppHokErrorData
    {
        [JsonPropertyName("details")]
        public string? Details { get; set; } // Error details
    }

    public class WAppHokMessage
    {
        [JsonPropertyName("from")]
        public string? From { get; set; } // Customer's WhatsApp ID

        [JsonPropertyName("id")]
        public string? Id { get; set; } // Message ID

        [JsonPropertyName("timestamp")]
        public string? Timestamp { get; set; } // Timestamp

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppHokMessageType? Type { get; set; } // Message type

        [JsonPropertyName("text")]
        public WAppHokText? Text { get; set; } // Text object

        [JsonPropertyName("audio")]
        public WAppHokAudio? Audio { get; set; } // Audio object

        [JsonPropertyName("button")]
        public WAppHokButton? Button { get; set; } // Button object

        [JsonPropertyName("context")]
        public WAppHokContext? Context { get; set; } // Context object

        [JsonPropertyName("document")]
        public WAppHokDocument? Document { get; set; } // Document object

        [JsonPropertyName("image")]
        public WAppHokImage? Image { get; set; } // Image object

        [JsonPropertyName("interactive")]
        public WAppHokInteractive? Interactive { get; set; } // Interactive object

        [JsonPropertyName("order")]
        public WAppHokOrder? Order { get; set; } // Order object

        [JsonPropertyName("referral")]
        public WAppHokReferral? Referral { get; set; } // Referral object

        [JsonPropertyName("sticker")]
        public WAppHokSticker? Sticker { get; set; } // Sticker object

        [JsonPropertyName("system")]
        public WAppHokSystem? System { get; set; } // System object

        [JsonPropertyName("video")]
        public WAppHokVideo? Video { get; set; } // Video object
    }

    public class WAppHokText
    {
        [JsonPropertyName("body")]
        public string? Body { get; set; } // Text body
    }

    public class WAppHokAudio
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; } // Audio ID

        [JsonPropertyName("mime_type")]
        public string? MimeType { get; set; } // Mime type
    }

    public class WAppHokButton
    {
        [JsonPropertyName("payload")]
        public string? Payload { get; set; } // Button payload

        [JsonPropertyName("text")]
        public string? Text { get; set; } // Button text
    }

    public class WAppHokContext
    {
        [JsonPropertyName("forwarded")]
        public bool? Forwarded { get; set; } // Forwarded flag

        [JsonPropertyName("frequently_forwarded")]
        public bool? FrequentlyForwarded { get; set; } // Frequently forwarded flag

        [JsonPropertyName("from")]
        public string? From { get; set; } // Customer's WhatsApp ID

        [JsonPropertyName("id")]
        public string? Id { get; set; } // Message ID

        [JsonPropertyName("referred_product")]
        public WAppHokReferredProduct? ReferredProduct { get; set; } // Referred product object
    }

    public class WAppHokReferredProduct
    {
        [JsonPropertyName("catalog_id")]
        public string? CatalogId { get; set; } // Catalog ID

        [JsonPropertyName("product_retailer_id")]
        public string? ProductRetailerId { get; set; } // Product retailer ID
    }

    public class WAppHokDocument
    {
        [JsonPropertyName("caption")]
        public string? Caption { get; set; } // Document caption

        [JsonPropertyName("filename")]
        public string? Filename { get; set; } // Document filename

        [JsonPropertyName("sha256")]
        public string? Sha256 { get; set; } // Document SHA256 hash

        [JsonPropertyName("mime_type")]
        public string? MimeType { get; set; } // Mime type

        [JsonPropertyName("id")]
        public string? Id { get; set; } // Document ID
    }

    public class WAppHokImage
    {
        [JsonPropertyName("caption")]
        public string? Caption { get; set; } // Image caption

        [JsonPropertyName("sha256")]
        public string? Sha256 { get; set; } // Image SHA256 hash

        [JsonPropertyName("id")]
        public string? Id { get; set; } // Image ID

        [JsonPropertyName("mime_type")]
        public string? MimeType { get; set; } // Mime type
    }

    public class WAppHokInteractive
    {
        [JsonPropertyName("type")]
        public WAppHokInteractiveType? Type { get; set; } // Interactive type
    }

    public class WAppHokInteractiveType
    {
        [JsonPropertyName("button_reply")]
        public WAppHokButtonReply? ButtonReply { get; set; } // Button reply object

        [JsonPropertyName("list_reply")]
        public WAppHokListReply? ListReply { get; set; } // List reply object
    }

    public class WAppHokButtonReply
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; } // Button reply ID

        [JsonPropertyName("title")]
        public string? Title { get; set; } // Button reply title
    }

    public class WAppHokListReply
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; } // List reply ID

        [JsonPropertyName("title")]
        public string? Title { get; set; } // List reply title

        [JsonPropertyName("description")]
        public string? Description { get; set; } // List reply description
    }

    public class WAppHokOrder
    {
        [JsonPropertyName("catalog_id")]
        public string? CatalogId { get; set; } // Catalog ID

        [JsonPropertyName("text")]
        public string? Text { get; set; } // Order text

        [JsonPropertyName("product_items")]
        public List<WAppHokProductItem>? ProductItems { get; set; } // List of product items
    }

    public class WAppHokProductItem
    {
        [JsonPropertyName("product_retailer_id")]
        public string? ProductRetailerId { get; set; } // Product retailer ID

        [JsonPropertyName("quantity")]
        public string? Quantity { get; set; } // Quantity

        [JsonPropertyName("item_price")]
        public string? ItemPrice { get; set; } // Item price

        [JsonPropertyName("currency")]
        public string? Currency { get; set; } // Currency
    }

    public class WAppHokReferral
    {
        [JsonPropertyName("source_url")]
        public string? SourceUrl { get; set; } // Source URL

        [JsonPropertyName("source_type")]
        public string? SourceType { get; set; } // Source type

        [JsonPropertyName("source_id")]
        public string? SourceId { get; set; } // Source ID

        [JsonPropertyName("headline")]
        public string? Headline { get; set; } // Headline

        [JsonPropertyName("body")]
        public string? Body { get; set; } // Body

        [JsonPropertyName("media_type")]
        public string? MediaType { get; set; } // Media type

        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; } // Image URL

        [JsonPropertyName("video_url")]
        public string? VideoUrl { get; set; } // Video URL

        [JsonPropertyName("thumbnail_url")]
        public string? ThumbnailUrl { get; set; } // Thumbnail URL

        [JsonPropertyName("ctwa_clid")]
        public string? CtwaClid { get; set; } // Click to WhatsApp click ID
    }

    public class WAppHokSticker
    {
        [JsonPropertyName("mime_type")]
        public string? MimeType { get; set; } // Mime type

        [JsonPropertyName("sha256")]
        public string? Sha256 { get; set; } // SHA256 hash

        [JsonPropertyName("id")]
        public string? Id { get; set; } // Sticker ID

        [JsonPropertyName("animated")]
        public bool? Animated { get; set; } // Animated flag
    }

    public class WAppHokSystem
    {
        [JsonPropertyName("body")]
        public string? Body { get; set; } // System body

        [JsonPropertyName("identity")]
        public string? Identity { get; set; } // Identity

        [JsonPropertyName("new_wa_id")]
        public string? NewWaId { get; set; } // New WhatsApp ID

        [JsonPropertyName("wa_id")]
        public string? WaId { get; set; } // WhatsApp ID

        [JsonPropertyName("type")]
        public string? Type { get; set; } // System type

        [JsonPropertyName("customer")]
        public string? Customer { get; set; } // Customer
    }

    public class WAppHokVideo
    {
        [JsonPropertyName("caption")]
        public string? Caption { get; set; } // Video caption

        [JsonPropertyName("filename")]
        public string? Filename { get; set; } // Video filename

        [JsonPropertyName("sha256")]
        public string? Sha256 { get; set; } // SHA256 hash

        [JsonPropertyName("id")]
        public string? Id { get; set; } // Video ID

        [JsonPropertyName("mime_type")]
        public string? MimeType { get; set; } // Mime type
    }

    public class WAppHokStatus
    {
        [JsonPropertyName("biz_opaque_callback_data")]
        public string? BizOpaqueCallbackData { get; set; } // Callback data

        [JsonPropertyName("conversation")]
        public WAppHokConversation? Conversation { get; set; } // Conversation object

        [JsonPropertyName("errors")]
        public List<WAppHokError>? Errors { get; set; } // List of errors

        [JsonPropertyName("id")]
        public string? Id { get; set; } // Status ID

        [JsonPropertyName("pricing")]
        public WAppHokPricing? Pricing { get; set; } // Pricing object

        [JsonPropertyName("recipient_id")]
        public string? RecipientId { get; set; } // Recipient ID

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppHokStatusType? StatusValue { get; set; } // Status value

        [JsonPropertyName("timestamp")]
        public string? Timestamp { get; set; } // Timestamp
    }

    public class WAppHokConversation
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; } // Conversation ID

        [JsonPropertyName("origin")]
        public WAppHokOrigin? Origin { get; set; } // Origin object

        [JsonPropertyName("expiration_timestamp")]
        public string? ExpirationTimestamp { get; set; } // Expiration timestamp
    }

    public class WAppHokOrigin
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppHokOriginType? Type { get; set; } // Origin type

        [JsonPropertyName("authentication")]
        public string? Authentication { get; set; } // Authentication

        [JsonPropertyName("marketing")]
        public string? Marketing { get; set; } // Marketing

        [JsonPropertyName("utility")]
        public string? Utility { get; set; } // Utility

        [JsonPropertyName("service")]
        public string? Service { get; set; } // Service

        [JsonPropertyName("referral_conversion")]
        public string? ReferralConversion { get; set; } // Referral conversion
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppHokOriginType
    {
        authentication,
        marketing,
        utility,
        service,
        referral_conversion
    }

    public class WAppHokPricing
    {
        [JsonPropertyName("billable")]
        public bool? Billable { get; set; } // Billable flag

        [JsonPropertyName("category")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WAppHokPricingCategory? Category { get; set; } // Pricing category

        [JsonPropertyName("pricing_model")]
        public string? PricingModel { get; set; } // Pricing model
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppHokPricingCategory
    {
        authentication,
        authentication_international,
        marketing,
        utility,
        service,
        referral_conversion
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppHokStatusType
    {
        delivered,
        read,
        sent
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WAppHokMessageType
    {
        text,
        audio,
        button,
        document,
        image,
        interactive,
        order,
        referral,
        sticker,
        system,
        video
    }
}
