# Notes 03/05/2019

## HTML
- Hyper Text Markup Language
- old HTML -> HTML 4 (old to new)
    - Browser wars back then where each browser competed directly with each other rather than working together
    - Each has their own version of HTML
    - Upon moving to HTML 4, HTML became more standard (except for internet explorer)
- HTML 4 -> XHTML
    - XHTML is a subset of XML
        - Error handling is well-defined
        - Web developers are barbarians and wouldn't have it
- HtML 4 -> HTML 5
    - HTML 5 is the modern version
    - A bit of a compromise, does have error handling
    - HTML 5 has a "living standard" and what that is is anyone's guess
- W3C, WWW Consortium
    - Responsible for XHTML
    - Fallen out of relevance
- WHATWG
    - Web Hypertext Application Technology Working Group
    - Work to improve consistency of HTML, but in a free-form web-developer-y way
- Separation of Concerns 
    - HTML
        - structure, semantics (what is the meaning of what's written)
    - CSS
        - Appearance, layout, presentation
    - Javascript
        - Dynamic client side behavior
- Syntax
    - Element: <tagname attributename = "attribute-value" contents>
        - <> = opening and closing tags
        - attribute: attributename = "attribute-value"
    - Some tags like input and image do not have a required closing tag
        - <input attribute = value /> : this is a self-closing tag
    - Lists of values in attribute are space-separated 
        - e.g. data = "1 2 3"
    - Attributes
        - Id, class, title, style, "on __ event handlers"
            - Id: lets CSS and JS reference a specific element by a unique Id
            - Class: No purpose unless CSS and/or JS is being used with it. It's a grouping of elements for CSS/JS to target.
            - Title: Hovertool tip text
            - Style: For inline-CSS
            - Event Handler: JS relevant
- Mozilla developer network is the "proper" behavior and attributes of HTML 5
    - https://developer.mozilla.org/en-US/ 
 - How user interacts with html file
    - There's a server and a browser 
        - Browser could be www.facebook.com
        - Then there's a DNS (domain name service)
        - The DNS contacts the browser with an IP address, and the browser tries to access the DNS in turn to make sure it's up to date
        - A DNS cache means that the browser doesn't need to access the DNS every single time it does something

## CSS
- Cascading style sheets
- Composed of rules
    - table, th, td {border 1px solid black; }
        - this is all one rule
        - table, th, td = the selector, when the rule will apply to
        - border = property
        - 1px solid black = value
        - Though "border: 1px solid black" is also a property its entirety
- Selectors (CSS selectors):

| Name        | Example        | Descriptor                                |
|-------------|----------------|-------------------------------------------|
| *           | *              | all elements                              |
| tag         | div            | all with tag(div)                         |
| .class      | .login-form    | all with class (all class = "login-form") |
| #id         | #logo-img      | the  one with id (id = "logo-img"         |
| [attr=val]  | [src=logo.png] | all with attribute set to value           |
| [attr~=val] | [class~=asdf]  | all with attribute containing value       |
| ,           | p,div          | all matching either selector (OR)         |
| concatenate | p.login        | all matching both selector (AND)                                                      |
| >           | p>div          | "parent child" - all matching 2nd selector that are children of some matching 1st selector |
| (space)     | div p          | "ancester descedenat" - all matching 2nd selector that are descedants of some matching 1st selector |
| +           | p + p          | "next sibling" -all matching 2nd selector that are siblings directly after some matching 1st selector |
| ~           | p ~ p          | "any sibling" - all matching 2nd selector that are any sibling of some matching 1st selector          |

- pseudo-class
    - select elements in some state
    - at end of selector and start with :
        - :valid
        - :invalid
        - :link
        - :visited
        - :active
        - :focus
        - :hover
        - :nth-child(aN+b)
            - ex: :nth-child(2N) and :nth-child(2N+1)
            - can use to create a sequence of elements that alternates something (color, shade, etc.)
        - :first-child
        - :last-child
- pseudo-element
    - we use <selector> ::
    - :: before
    - :: after
        - ex: a.external::after {content: "--"}
    - :: selection (what the user is highlighting)
- The cascade
    - When multiple rules set the same property on an element, which one wins?
        1. Importance
            - Can make rules extra important by placing !important after a rule, but this is bad practice           
        2. Specificity
            - First, inline wins
            - Next, whoever has more ID selectors wins
            - Next, whoever has more class selectors
            - Next, whoever has more tag selectors
            - Overall, the more specific the scope, the more priority they have
        3. Source order
            - The later rule wins if all other things are equal
    - Types of style sheets:
        - User-agent styles
            - Browser defaults
            - E.g. font is times new roman
        - Author styles
            - CSS included on documents
            - 3 ways to include CSS on document
                1. In the HTML Head - <link rel = "stylesheet" href = "main.css"> - External //the best and proper practice
                2. In the HTML Head - <style>p {font-weight: bold;}</style>- Internal //cannot be easily reused
                3. In inline body - <p style="border: 1px solid black">This is a stylized line</p> //violates separation of concerns
- **Box model**
    - All non-content elements have -right/-left/-top/-bottom properties
    - The order it top/right/bottom/left like a clock, so {margin: 1, 2, 3, 4} is 1 top, 2 right, 3 bottom, 4 left
    - *Margin*
        - *Border*
            - *Padding*
                - *Contents*