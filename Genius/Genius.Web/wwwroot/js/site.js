// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// External Login
window.fbAsyncInit = function () {
    FB.init({
        appId: '1305559539512274',
        cookie: true,
        xfbml: true,
        version: 'v3.2'
    });

    FB.AppEvents.logPageView();

};

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement(s); js.id = id;
    js.src = "https://connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

FB.getLoginStatus(function (response) {
    statusChangeCallback(response);
});
// Write your JavaScript code.
function textSelected() {
    var text = "";
    if (window.getSelection) {
        text = window.getSelection().toString();
    } else if (document.selection && document.selection.type !== "Control") {
        text = document.selection.createRange().text;
    }

    const annotationDiv = document.getElementById('add-annotation');

    if (text.length > 0) {
        const addAnnotationText = document.getElementById('add-annotation-text');
        annotationDiv.style.display = "block";
        addAnnotationText.innerHTML = text;

        const editAnnotationDiv = document.getElementById('edit-annotation').style.display = "none";
        const viewAnnotationDiv = document.getElementById('view-annotation').style.display = "none";
    } else {
        annotationDiv.style.display = "none"
    }
}

function clearSelection() {
    if (window.getSelection) {
        if (window.getSelection().empty) {  // Chrome
            window.getSelection().empty();
        } else if (window.getSelection().removeAllRanges) {  // Firefox
            window.getSelection().removeAllRanges();
        }
    } else if (document.selection) {  // IE?
        document.selection.empty();
    }

    const annotationDiv = document.getElementById('add-annotation');
    annotationDiv.style.display = "none";
}

function viewAnnotation(id, text, content, author, editable) {
    clearSelection()

    if (editable) {
        const annotationDiv = document.getElementById('edit-annotation');
        const annotationId = document.getElementById('edit-annotation-id');
        const deleteAnnotationId = document.getElementById('delete-annotation-id');
        const annotationContent = document.getElementById('edit-annotation-content');
        annotationDiv.style.display = "block";
        annotationId.value = id;
        deleteAnnotationId.value = id;
        annotationContent.value = content
    } else {
        const annotationDiv = document.getElementById('view-annotation');
        const annotationContent = document.getElementById('view-annotation-content');
        const annotationAuthor = document.getElementById('view-annotation-author');
        annotationDiv.style.display = "block";
        annotationContent.innerHTML = content;
        annotationAuthor.innerHTML = author
    }
}
