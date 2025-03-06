// Define the functions
function LoadWrld01() {
  window.location.href = "https://rubbedgenie.com/about.html";
  console.log("off to Wrld01");
}

function LoadWrld02() {
  window.location.href = "https://rubbedgenie.com/index.html";
  console.log("off to Wrld02");
}

function LoadWrld03() {
  window.location.href = "https://rubbedgenie.com/contact.html";
  console.log("off to Wrld03");
}

function LoadWrld04() {
  window.location.href = "https://rubbedgenie.com/projects.html";
  console.log("off to Wrld04");
}

// Merge the functions into LibraryManager.library
mergeInto(LibraryManager.library, {
  LoadWrld01: LoadWrld01,
  LoadWrld02: LoadWrld02,
  LoadWrld03: LoadWrld03,
  LoadWrld04: LoadWrld04,
});
