function traverseNodesBySelector(selector, spacing) {
    spacing = spacing || '';
    var node = document.body.querySelector(selector);

    if (node.id) {
        console.log(spacing + node.tagName.toLowerCase() + ': id= "' + node.id + '" ,class="' + node.className + '"');
    }
    else {
        console.log(spacing + node.tagName.toLowerCase() + ': class="' + node.className + '"');
    }.



 }
traverseNodesBySelector('.bird');