function drop(ev) {
    ev.preventDefault();
    var itemId = ev.dataTransfer.getData("itemId");
    var list = ev.target.getElementsByTagName("ul")[0];
    list.appendChild(document.getElementById(itemId).cloneNode(true));
}

function drag(ev) {
    ev.dataTransfer.setData("itemId", ev.target.id);
}

function allowDrop(ev) {
    ev.preventDefault();
}