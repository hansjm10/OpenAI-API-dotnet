﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAI_API.Chat
{
	/// <summary>
	/// Chat message sent or received from the API. Includes who is speaking in the "role" and the message text in the "content"
	/// </summary>
	public class ChatMessage
	{
		/// <summary>
		/// Creates an empty <see cref="ChatMessage"/>, with <see cref="Role"/> defaulting to <see cref="ChatMessageRole.User"/>
		/// </summary>
		public ChatMessage()
		{
			Role = ChatMessageRole.User;
			Id = Guid.NewGuid();
		}

		/// <summary>
		/// Constructor for a new Chat Message
		/// </summary>
		/// <param name="role">The role of the message, which can be "system", "assistant" or "user"</param>
		/// <param name="content">The text to send in the message</param>
		public ChatMessage(ChatMessageRole role, string content)
		{
			Role = role;
			Content = content;
			Id = Guid.NewGuid();
		}
		
		/// <summary>
		/// Constructor for a new Chat Message
		/// </summary>
		/// <param name="role">The role of the message, which can be "system", "assistant" or "user"</param>
		/// <param name="content">The text to send in the message</param>
		/// <param name="id">Unique guid acting as an identifier. If null, assigned automatically.</param>
		public ChatMessage(ChatMessageRole role, string content, Guid? id)
		{
			Role = role;
			Content = content;
			Id = id ?? Guid.NewGuid();
		}

		[JsonProperty("role")]
		internal string rawRole { get; set; }

		/// <summary>
		/// The role of the message, which can be "system", "assistant" or "user"
		/// </summary>
		[JsonIgnore]
		public ChatMessageRole Role
		{
			get => ChatMessageRole.FromString(rawRole);
			set => rawRole = value.ToString();
		}

		/// <summary>
		/// The content of the message
		/// </summary>
		[JsonProperty("content")]
		public string Content { get; set; }

		/// <summary>
		/// An optional name of the user in a multi-user chat 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
		
		/// <summary>
		/// Assigned in ctor. Use to remove / update messages from conversation.s
		/// </summary>
		[JsonIgnore]
		public Guid Id { get; }
	}
}
