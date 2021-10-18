// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ViewFile(id, linkClicked){
    let fileViewer = "fileViewer_" + id
    let fileLink = "fileLink_" + id

    if(linkClicked){
        $("#" + fileViewer).show()
        $("#" + fileLink).hide()
    }
    else{
        $("#" + fileViewer).hide()
        $("#" + fileLink).show()
    }
}

function ConfirmDelete(id, deleteClicked) {
    let confirmDeleteSpan = "confirmDeleteSpan_" + id
    let deleteSpan = "deleteSpan_" + id

    if (deleteClicked) {
        $("#" + confirmDeleteSpan).show()
        $("#" + deleteSpan).hide()
    }
    else {
        $("#" + confirmDeleteSpan).hide()
        $("#" + deleteSpan).show()
    }
}