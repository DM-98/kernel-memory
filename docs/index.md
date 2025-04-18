---
nav_order: 1
has_children: false
title: Overview
permalink: /
layout: default
---
# Kernel Memory

[![License: MIT](https://img.shields.io/github/license/microsoft/kernel-memory)](https://github.com/microsoft/kernel-memory/blob/main/LICENSE)
[![Discord](https://img.shields.io/discord/1063152441819942922?label=Discord&logo=discord&logoColor=white&color=d82679)](https://aka.ms/KMdiscord)

**Kernel Memory** (KM) is a **multi-modal [AI Service](service/Service/README.md)**
specialized in the efficient indexing of documents and information through custom continuous data
pipelines, with support for
**[Retrieval Augmented Generation](https://en.wikipedia.org/wiki/Prompt_engineering#Retrieval-augmented_generation)** (RAG),
synthetic memory, prompt engineering, and custom semantic memory processing.

KM supports PDF and Word documents, PowerPoint presentations, Images, Spreadsheets [and more](extensions/data-formats),
extracting information and generating memories by leveraging Large Language Models (LLMs), Embeddings and Vector
storage.

![image](https://github.com/microsoft/kernel-memory/assets/371009/31894afa-d19e-4e9b-8d0f-cb889bf5c77f)

Utilizing advanced embeddings, LLMs and prompt engineering, the system enables Natural Language
**querying for obtaining answers** from the information stored, complete with citations
and links to the original sources.

![image](https://github.com/microsoft/kernel-memory/assets/371009/c5f0f6c3-814f-45bf-b055-063f23ed80ea)

Kernel Memory is designed for seamless integration with any programming language, providing a
web service that can also be consumed as an [OpenAPI endpoint for ChatGPT](https://openai.com/blog/chatgpt-plugins),
web clients ready to use, and a Plugin
for [Microsoft Copilot](https://www.microsoft.com/microsoft-365/blog/2023/05/23/empowering-every-developer-with-plugins-for-microsoft-365-copilot)
and [Semantic Kernel](https://github.com/microsoft/semantic-kernel).

# Topics

* [Quickstart: test KM in few minutes](quickstart)
* [**Memory service**, web clients and plugins](service)
* [**Memory API**, memory ingestion and information retrieval](functions)
* [KM **Extensions**: vector DBs, AI models, Data formats, Orchestration, Content storage](extensions)
* [Embedding **serverless** memory in .NET apps](serverless)
* [**Security**, service and users](security)
* [**How-to guides**, customizing KM and examples](how-to)
* [**Concepts**, KM glossary](concepts)
* [KM packages](packages)