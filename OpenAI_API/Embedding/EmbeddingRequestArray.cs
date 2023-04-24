﻿using System.Collections.Generic;
using Newtonsoft.Json;
using OpenAI_API.Models;

namespace OpenAI_API.Embedding
{
	/// <summary>
	/// Represents a request to the Completions API. Matches with the docs at <see href="https://platform.openai.com/docs/api-reference/embeddings">the OpenAI docs</see>
	/// </summary>
	public class EmbeddingRequestArray
	{
		/// <summary>
		/// ID of the model to use. You can use <see cref="ModelsEndpoint.GetModelsAsync()"/> to see all of your available models, or use a standard model like <see cref="Model.AdaTextEmbedding"/>.
		/// </summary>
		[JsonProperty("model")]
		public string Model { get; set; }

		/// <summary>
		/// Main text to be embedded
		/// </summary>
		[JsonProperty("input")]
		public IEnumerable<string> Input { get; set; }

		/// <summary>
		/// Cretes a new, empty <see cref="EmbeddingRequest"/>
		/// </summary>
		public EmbeddingRequestArray()
		{

		}

		/// <summary>
		/// Creates a new <see cref="EmbeddingRequest"/> with the specified parameters
		/// </summary>
		/// <param name="model">The model to use. You can use <see cref="ModelsEndpoint.GetModelsAsync()"/> to see all of your available models, or use a standard model like <see cref="Model.AdaTextEmbedding"/>.</param>
		/// <param name="input">The prompt to transform</param>
		public EmbeddingRequestArray(Model model, IEnumerable<string> input)
		{
			Model = model;
			Input = input;
		}

		/// <summary>
		/// Creates a new <see cref="EmbeddingRequest"/> with the specified input and the <see cref="Model.AdaTextEmbedding"/> model.
		/// </summary>
		/// <param name="input">The prompt to transform</param>
		public EmbeddingRequestArray(IEnumerable<string> input)
		{
			Model = OpenAI_API.Models.Model.AdaTextEmbedding;
			Input = input;
		}
	}
}
