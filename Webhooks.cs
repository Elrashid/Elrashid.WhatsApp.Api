using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Elrashid.WhatsApp.Api.Webhooks
{
    public class WAppHokWebhookNotification
    {
        [JsonProperty("object")]
        public string? Object { get; set; } // The webhook type (e.g., "whatsapp_business_account")

        [JsonProperty("entry")]
        public List<WAppHokEntry>? Entries { get; set; } // List of entries

        public class WAppHokEntry
        {
            [JsonProperty("id")]
            public string? Id { get; set; } // WhatsApp Business Account ID

            [JsonProperty("changes")]
            public List<WAppHokChange>? Changes { get; set; } // List of changes

            public class WAppHokChange
            {
                [JsonProperty("value")]
                public WAppHokValue? Value { get; set; } // Value object

                [JsonProperty("field")]
                public string? Field { get; set; } // Notification type (e.g., "messages")

                public class WAppHokValue
                {
                    [JsonProperty("messaging_product")]
                    public string? MessagingProduct { get; set; } // Product used to send the message (always "whatsapp")

                    [JsonProperty("metadata")]
                    public WAppHokMetadata? Metadata { get; set; } // Metadata object

                    [JsonProperty("contacts")]
                    public List<WAppHokContact>? Contacts { get; set; } // List of contacts

                    [JsonProperty("errors")]
                    public List<WAppHokError>? Errors { get; set; } // List of errors

                    [JsonProperty("messages")]
                    public List<WAppHokMessage>? Messages { get; set; } // List of messages

                    [JsonProperty("statuses")]
                    public List<WAppHokStatus>? Statuses { get; set; } // List of statuses

                    public class WAppHokMetadata
                    {
                        [JsonProperty("display_phone_number")]
                        public string? DisplayPhoneNumber { get; set; } // Display phone number

                        [JsonProperty("phone_number_id")]
                        public string? PhoneNumberId { get; set; } // Phone number ID
                    }

                    public class WAppHokContact
                    {
                        [JsonProperty("wa_id")]
                        public string? WaId { get; set; } // Customer's WhatsApp ID

                        [JsonProperty("profile")]
                        public WAppHokProfile? Profile { get; set; } // Profile object

                        public class WAppHokProfile
                        {
                            [JsonProperty("name")]
                            public string? Name { get; set; } // Customer's name
                        }
                    }

                    public class WAppHokError
                    {
                        [JsonProperty("code")]
                        public int? Code { get; set; } // Error code

                        [JsonProperty("title")]
                        public string? Title { get; set; } // Error title

                        [JsonProperty("message")]
                        public string? Message { get; set; } // Error message

                        [JsonProperty("error_data")]
                        public WAppHokErrorData? ErrorData { get; set; } // Error data object

                        public class WAppHokErrorData
                        {
                            [JsonProperty("details")]
                            public string? Details { get; set; } // Error details
                        }
                    }

                    public class WAppHokMessage
                    {
                        [JsonProperty("from")]
                        public string? From { get; set; } // Customer's WhatsApp ID

                        [JsonProperty("id")]
                        public string? Id { get; set; } // Message ID

                        [JsonProperty("timestamp")]
                        public string? Timestamp { get; set; } // Timestamp

                        [JsonProperty("type")]
                        public WAppHokMessageType? Type { get; set; } // Message type

                        [JsonProperty("text")]
                        public WAppHokText? Text { get; set; } // Text object

                        [JsonProperty("audio")]
                        public WAppHokAudio? Audio { get; set; } // Audio object

                        [JsonProperty("button")]
                        public WAppHokButton? Button { get; set; } // Button object

                        [JsonProperty("context")]
                        public WAppHokContext? Context { get; set; } // Context object

                        [JsonProperty("document")]
                        public WAppHokDocument? Document { get; set; } // Document object

                        [JsonProperty("image")]
                        public WAppHokImage? Image { get; set; } // Image object

                        [JsonProperty("interactive")]
                        public WAppHokInteractive? Interactive { get; set; } // Interactive object

                        [JsonProperty("order")]
                        public WAppHokOrder? Order { get; set; } // Order object

                        [JsonProperty("referral")]
                        public WAppHokReferral? Referral { get; set; } // Referral object

                        [JsonProperty("sticker")]
                        public WAppHokSticker? Sticker { get; set; } // Sticker object

                        [JsonProperty("system")]
                        public WAppHokSystem? System { get; set; } // System object

                        [JsonProperty("video")]
                        public WAppHokVideo? Video { get; set; } // Video object

                        public class WAppHokText
                        {
                            [JsonProperty("body")]
                            public string? Body { get; set; } // Text body
                        }

                        public class WAppHokAudio
                        {
                            [JsonProperty("id")]
                            public string? Id { get; set; } // Audio ID

                            [JsonProperty("mime_type")]
                            public string? MimeType { get; set; } // Mime type
                        }

                        public class WAppHokButton
                        {
                            [JsonProperty("payload")]
                            public string? Payload { get; set; } // Button payload

                            [JsonProperty("text")]
                            public string? Text { get; set; } // Button text
                        }

                        public class WAppHokContext
                        {
                            [JsonProperty("forwarded")]
                            public bool? Forwarded { get; set; } // Forwarded flag

                            [JsonProperty("frequently_forwarded")]
                            public bool? FrequentlyForwarded { get; set; } // Frequently forwarded flag

                            [JsonProperty("from")]
                            public string? From { get; set; } // Customer's WhatsApp ID

                            [JsonProperty("id")]
                            public string? Id { get; set; } // Message ID

                            [JsonProperty("referred_product")]
                            public WAppHokReferredProduct? ReferredProduct { get; set; } // Referred product object

                            public class WAppHokReferredProduct
                            {
                                [JsonProperty("catalog_id")]
                                public string? CatalogId { get; set; } // Catalog ID

                                [JsonProperty("product_retailer_id")]
                                public string? ProductRetailerId { get; set; } // Product retailer ID
                            }
                        }

                        public class WAppHokDocument
                        {
                            [JsonProperty("caption")]
                            public string? Caption { get; set; } // Document caption

                            [JsonProperty("filename")]
                            public string? Filename { get; set; } // Document filename

                            [JsonProperty("sha256")]
                            public string? Sha256 { get; set; } // Document SHA256 hash

                            [JsonProperty("mime_type")]
                            public string? MimeType { get; set; } // Mime type

                            [JsonProperty("id")]
                            public string? Id { get; set; } // Document ID
                        }

                        public class WAppHokImage
                        {
                            [JsonProperty("caption")]
                            public string? Caption { get; set; } // Image caption

                            [JsonProperty("sha256")]
                            public string? Sha256 { get; set; } // Image SHA256 hash

                            [JsonProperty("id")]
                            public string? Id { get; set; } // Image ID

                            [JsonProperty("mime_type")]
                            public string? MimeType { get; set; } // Mime type
                        }

                        public class WAppHokInteractive
                        {
                            [JsonProperty("type")]
                            public WAppHokInteractiveType? Type { get; set; } // Interactive type

                            public class WAppHokInteractiveType
                            {
                                [JsonProperty("button_reply")]
                                public WAppHokButtonReply? ButtonReply { get; set; } // Button reply object

                                [JsonProperty("list_reply")]
                                public WAppHokListReply? ListReply { get; set; } // List reply object

                                public class WAppHokButtonReply
                                {
                                    [JsonProperty("id")]
                                    public string? Id { get; set; } // Button reply ID

                                    [JsonProperty("title")]
                                    public string? Title { get; set; } // Button reply title
                                }

                                public class WAppHokListReply
                                {
                                    [JsonProperty("id")]
                                    public string? Id { get; set; } // List reply ID

                                    [JsonProperty("title")]
                                    public string? Title { get; set; } // List reply title

                                    [JsonProperty("description")]
                                    public string? Description { get; set; } // List reply description
                                }
                            }
                        }

                        public class WAppHokOrder
                        {
                            [JsonProperty("catalog_id")]
                            public string? CatalogId { get; set; } // Catalog ID

                            [JsonProperty("text")]
                            public string? Text { get; set; } // Order text

                            [JsonProperty("product_items")]
                            public List<WAppHokProductItem>? ProductItems { get; set; } // List of product items

                            public class WAppHokProductItem
                            {
                                [JsonProperty("product_retailer_id")]
                                public string? ProductRetailerId { get; set; } // Product retailer ID

                                [JsonProperty("quantity")]
                                public string? Quantity { get; set; } // Quantity

                                [JsonProperty("item_price")]
                                public string? ItemPrice { get; set; } // Item price

                                [JsonProperty("currency")]
                                public string? Currency { get; set; } // Currency
                            }
                        }

                        public class WAppHokReferral
                        {
                            [JsonProperty("source_url")]
                            public string? SourceUrl { get; set; } // Source URL

                            [JsonProperty("source_type")]
                            public string? SourceType { get; set; } // Source type

                            [JsonProperty("source_id")]
                            public string? SourceId { get; set; } // Source ID

                            [JsonProperty("headline")]
                            public string? Headline { get; set; } // Headline

                            [JsonProperty("body")]
                            public string? Body { get; set; } // Body

                            [JsonProperty("media_type")]
                            public string? MediaType { get; set; } // Media type

                            [JsonProperty("image_url")]
                            public string? ImageUrl { get; set; } // Image URL

                            [JsonProperty("video_url")]
                            public string? VideoUrl { get; set; } // Video URL

                            [JsonProperty("thumbnail_url")]
                            public string? ThumbnailUrl { get; set; } // Thumbnail URL

                            [JsonProperty("ctwa_clid")]
                            public string? CtwaClid { get; set; } // Click to WhatsApp click ID
                        }

                        public class WAppHokSticker
                        {
                            [JsonProperty("mime_type")]
                            public string? MimeType { get; set; } // Mime type

                            [JsonProperty("sha256")]
                            public string? Sha256 { get; set; } // SHA256 hash

                            [JsonProperty("id")]
                            public string? Id { get; set; } // Sticker ID

                            [JsonProperty("animated")]
                            public bool? Animated { get; set; } // Animated flag
                        }

                        public class WAppHokSystem
                        {
                            [JsonProperty("body")]
                            public string? Body { get; set; } // System body

                            [JsonProperty("identity")]
                            public string? Identity { get; set; } // Identity

                            [JsonProperty("new_wa_id")]
                            public string? NewWaId { get; set; } // New WhatsApp ID

                            [JsonProperty("wa_id")]
                            public string? WaId { get; set; } // WhatsApp ID

                            [JsonProperty("type")]
                            public string? Type { get; set; } // System type

                            [JsonProperty("customer")]
                            public string? Customer { get; set; } // Customer
                        }

                        public class WAppHokVideo
                        {
                            [JsonProperty("caption")]
                            public string? Caption { get; set; } // Video caption

                            [JsonProperty("filename")]
                            public string? Filename { get; set; } // Video filename

                            [JsonProperty("sha256")]
                            public string? Sha256 { get; set; } // SHA256 hash

                            [JsonProperty("id")]
                            public string? Id { get; set; } // Video ID

                            [JsonProperty("mime_type")]
                            public string? MimeType { get; set; } // Mime type
                        }

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

                    public class WAppHokStatus
                    {
                        [JsonProperty("biz_opaque_callback_data")]
                        public string? BizOpaqueCallbackData { get; set; } // Callback data

                        [JsonProperty("conversation")]
                        public WAppHokConversation? Conversation { get; set; } // Conversation object

                        [JsonProperty("errors")]
                        public List<WAppHokError>? Errors { get; set; } // List of errors

                        [JsonProperty("id")]
                        public string? Id { get; set; } // Status ID

                        [JsonProperty("pricing")]
                        public WAppHokPricing? Pricing { get; set; } // Pricing object

                        [JsonProperty("recipient_id")]
                        public string? RecipientId { get; set; } // Recipient ID

                        [JsonProperty("status")]
                        public WAppHokStatusType? StatusValue { get; set; } // Status value

                        [JsonProperty("timestamp")]
                        public string? Timestamp { get; set; } // Timestamp

                        public class WAppHokConversation
                        {
                            [JsonProperty("id")]
                            public string? Id { get; set; } // Conversation ID

                            [JsonProperty("origin")]
                            public WAppHokOrigin? Origin { get; set; } // Origin object

                            [JsonProperty("expiration_timestamp")]
                            public string? ExpirationTimestamp { get; set; } // Expiration timestamp

                            public class WAppHokOrigin
                            {
                                [JsonProperty("type")]
                                public WAppHokOriginType? Type { get; set; } // Origin type

                                [JsonProperty("authentication")]
                                public string? Authentication { get; set; } // Authentication

                                [JsonProperty("marketing")]
                                public string? Marketing { get; set; } // Marketing

                                [JsonProperty("utility")]
                                public string? Utility { get; set; } // Utility

                                [JsonProperty("service")]
                                public string? Service { get; set; } // Service

                                [JsonProperty("referral_conversion")]
                                public string? ReferralConversion { get; set; } // Referral conversion

                                public enum WAppHokOriginType
                                {
                                    authentication,
                                    marketing,
                                    utility,
                                    service,
                                    referral_conversion
                                }
                            }
                        }

                        public class WAppHokPricing
                        {
                            [JsonProperty("billable")]
                            public bool? Billable { get; set; } // Billable flag

                            [JsonProperty("category")]
                            public WAppHokPricingCategory? Category { get; set; } // Pricing category

                            [JsonProperty("pricing_model")]
                            public string? PricingModel { get; set; } // Pricing model

                            public enum WAppHokPricingCategory
                            {
                                authentication,
                                authentication_international,
                                marketing,
                                utility,
                                service,
                                referral_conversion
                            }
                        }

                        public enum WAppHokStatusType
                        {
                            delivered,
                            read,
                            sent
                        }
                    }
                }
            }
        }
    }
}
