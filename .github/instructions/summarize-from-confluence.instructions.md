# Summarize from Confluence

**Visual Marker**: 📖

**Applies To**: All documentation tasks requiring information from Confluence

## Purpose

This instruction file defines the process for searching, retrieving, and summarizing content from Atlassian Confluence using the MCP (Model Context Protocol) tools. Use this when a user asks to create documentation based on Confluence content.

## Prerequisites

- Access to Atlassian MCP tools (`mcp_atlassian_*`)
- User has authenticated with Atlassian/Confluence
- The workspace has appropriate write permissions

## Step-by-Step Process

### 1. Search for Relevant Content

Use `mcp_atlassian_atl_search` to find relevant pages:

```
Parameters:
- query: Clear, concise search terms related to the topic
```

**Best Practices**:
- Use specific keywords from the user's request
- Avoid overly broad terms that may return too many results
- The search returns page titles, snippets, and URLs

### 2. Identify Key Pages

From the search results:
- Review page titles and text snippets
- Identify the 3-5 most relevant pages
- Prioritize pages with:
  - Mission statements
  - Definitions or "What is..." content
  - Best practices or guidelines
  - Community/organizational structure information

### 3. Retrieve Full Page Content

Use `mcp_atlassian_atl_getConfluencePage` for each identified page:

```
Parameters:
- pageId: Extract from the search results (e.g., "1026818105")
- cloudId: Extract from search results or use site URL (e.g., "8d1fd9fe-1328-4d74-84ef-b522c98cc629")
```

**Important**: Call this tool in parallel for multiple pages to improve efficiency.

**Note**: The tool returns page content in Markdown format, making it easy to process and reuse.

### 4. Synthesize and Structure the Summary

Create a comprehensive summary document that:

#### Structure Requirements:
1. **Title**: Clear, descriptive heading
2. **Introduction**: High-level overview of the topic
3. **Core Concepts**: Main definitions and principles
4. **Key Sections**: Organize by logical themes (e.g., mission, personas, practices, domains)
5. **Supporting Details**: Examples, characteristics, practices
6. **Nuances**: Important caveats or balanced perspectives
7. **Additional Resources**: Links to related pages and resources

#### Content Guidelines:
- Use clear headings (##, ###) to organize information hierarchically
- Include relevant quotes or key statements from source material
- Preserve important lists, frameworks, or models
- Maintain the original tone and terminology
- Balance comprehensiveness with readability

### 5. Add Source Attribution

For each major section or concept, add source links:

```markdown
> Source: [Page Title](https://aewiki.atlassian.net/wiki/spaces/SPACE/pages/ID/Title)
```

Place source attributions:
- Immediately after sections summarizing specific pages
- At the end of sections that synthesize multiple sources
- In an "Additional Resources" section at the end

### 6. Enrich with Hyperlinks

When the user requests (or proactively):

1. **Link key concepts** to:
   - External references (Wikipedia, official docs, authoritative blogs)
   - Internal Confluence pages
   - Community channels (Teams, Slack, etc.)

2. **Link technical terms** to:
   - Definitions
   - Best practice articles
   - Tutorial resources

3. **Link frameworks/methodologies** to:
   - Official documentation
   - Widely recognized sources (Martin Fowler, etc.)

**Format**: `[Term](URL)` - use inline links for better readability

### 7. File Naming and Location

- **Filename**: Use a clear, lowercase, hyphenated name reflecting the topic (e.g., `crafter.md`, `devops-practices.md`)
- **Location**: Root of the workspace or appropriate subdirectory
- **Format**: Always use Markdown (.md)

## Output Format Template

```markdown
# [Topic Title]

## What is [Topic]?

[High-level introduction and definition]

> Source: [Primary Source Page](URL)

## [Key Section 1]

[Content with inline links to key concepts]

> Source: [Relevant Source](URL)

## [Key Section 2]

[Content organized with headings, lists, and emphasis]

### [Subsection]

[Detailed information]

## Important Nuances

[Balanced perspective, caveats, or alternative views]

> Sources: [External Reference](URL), [Another Source](URL)

---

## Additional Resources

- [Resource 1](URL) - Description
- [Resource 2](URL) - Description
- [Community Channel](URL)
```

## Quality Checklist

Before completing the task, verify:

- ✅ All major concepts from source material are included
- ✅ Information is organized logically with clear headings
- ✅ Source attributions are present for all major sections
- ✅ Key terms and concepts have hyperlinks
- ✅ External and internal links are working (Confluence URLs)
- ✅ Document is readable and flows naturally
- ✅ Important nuances or caveats are included
- ✅ Additional resources section is comprehensive
- ✅ Markdown formatting is correct and consistent
- ✅ Visual marker 📖 is included in responses

## Common Pitfalls to Avoid

1. **Don't** rely solely on search snippets - always retrieve full page content
2. **Don't** copy-paste without synthesizing - create a coherent narrative
3. **Don't** omit source attribution - always credit Confluence pages
4. **Don't** forget to add hyperlinks - they greatly enhance usability
5. **Don't** ignore related pages - check the search results thoroughly
6. **Don't** create walls of text - use headings, lists, and emphasis
7. **Don't** lose important context - preserve frameworks, models, and structures

## Communication with User

When executing this instruction:

1. **Start**: Acknowledge the request and begin searching
2. **During**: Minimal narration - focus on execution
3. **Complete**: Brief confirmation with visual marker 📖
4. **Follow-up**: Offer to enrich with links if not already done

**Example**: "📖 Summarized [topic] from Confluence in `filename.md`."

## Related Tools

- `mcp_atlassian_atl_search` - Search Confluence content
- `mcp_atlassian_atl_getConfluencePage` - Retrieve full page content
- `mcp_atlassian_atl_searchConfluenceUsingCql` - Advanced search with CQL (for specific queries)
- `create_file` - Create the summary document
- `replace_string_in_file` - Add hyperlinks and enrich content

## Examples

### Good Search Queries
- "software crafter" (specific role/concept)
- "DevOps practices" (specific domain)
- "API guidelines" (specific topic)

### Poor Search Queries
- "software" (too broad)
- "best practices" (too generic)
- "documentation" (non-specific)

### Good Source Attribution
```markdown
> Source: [Crafter community - mission statement](https://aewiki.atlassian.net/wiki/spaces/KEN/pages/1387560990/Crafter+community+-+mission+statement)
```

### Poor Source Attribution
```markdown
Source: Confluence page
See wiki for details
```
