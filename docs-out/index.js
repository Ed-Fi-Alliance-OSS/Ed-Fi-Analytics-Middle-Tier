var markdownpdf = require('markdown-pdf'),
    fs = require('fs'),
    path = require('path'),
    through = require('through2');

const gitHubCssFile = path.join(__dirname, 'node_modules', 'primer-markdown', 'build', 'build.css');

const forBestViewing = `
    <div style="border: 1px solid green; padding: 1em; background-color: #dff0d8">
        This PDF does not include some hyperlinks and images. For the best reading experience,
        please visit the <a href="https://github.com/Ed-Fi-Alliance/Ed-Fi-X-Analytics-Middle-Tier">online 
        version of this document</a>.
    </div>
`;

const outputFile = 'analytics-middle-tier.pdf';
var outputPath = path.join(__dirname, outputFile);

const options = {
    cssPath: gitHubCssFile,
    preProcessHtml: () => {
        return through(function (data, _enc, cb) {

            // Primer-markdown has nice GitHub CSS - but it depends on class .markdown-body.
            // Wrap the body with that class. Also insert a tip suggesting a better way to
            // read this documentation.
            var wrapped = `<div class="markdown-body">${forBestViewing}${data.toString()}</div>`
                // Conversion utilities can't handle anchor or relative links properly,
                // so best to just strip them out entirely.
                .replace(/<a href=\"(?!https)[^\"]+\">([^<]+)<\/a>/g, '$1');

            // Uncomment below to write the HTML to file for debugging
            //fs.writeFileSync("output.html", wrapped, 'utf-8');

            this.push(wrapped);
            cb();
        })
    },
    paperFormat: 'Letter',
    paperBorder: '1in',
    remarkable: {
        breaks: false,
        baseUrl: './'
    }
};
var docs = [
    path.join(__dirname, '..', 'readme.md'),
    path.join(__dirname, '..', 'docs', 'installation.md'),
    path.join(__dirname, '..', 'docs', 'patterns-and-practices.md')
];


// We want to style the output using GitHub CSS. It has one particular annoyance -
// it forces horizontal scrolling on code samples. This does not work in PDF format.
// Pre-process that CSS file to remove this directive.

var data = fs.readFileSync(gitHubCssFile, 'utf-8');
data = data.replace('white-space:pre;', 'white-space:pre-wrap;')
fs.writeFileSync(gitHubCssFile, data, 'utf-8');


// Finally, perform the conversion
markdownpdf(options)
    .concat
    .from(docs)
    .to(outputPath, () => {
        console.log('Created', outputPath);
    });
