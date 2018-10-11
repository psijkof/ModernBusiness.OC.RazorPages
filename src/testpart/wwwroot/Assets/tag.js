
// @ts-check
var tags = [];
var showTags = document.getElementById('showTags');
var tagOut = document.getElementById('tagout');

function existingTags(modelTags) {
    console.log(modelTags);
    if (modelTags.length > 0) {
        var tagArray = modelTags.split(',');
        for (var i = 0; i < tagArray.length; i++) {
            addTag(tagArray[i]);
        }
    }
}

function addTag(text) {
    let tag = {
        text: text,
        element: document.createElement('span')
    };

    tag.element.classList.add('tag');
    tag.element.textContent = tag.text;

    let closeBtn = document.createElement('span');
    closeBtn.classList.add('close');
    closeBtn.addEventListener('click', function () {
        removeTag(tags.indexOf(tag));
    });
    tag.element.appendChild(closeBtn);

    tags.push(tag);
    showTags.appendChild(tag.element)
    
    //tagOut.setAttribute('value', tagOut.getAttribute('value') + tag.text);
    refreshTags();
}

function removeTag(index) {
    let tag = tags[index];
    tags.splice(index, 1)
    showTags.removeChild(tag.element);

    refreshTags();
}


function refreshTags() {
    let tagsList = [];
    tags.forEach(function (t) {
        tagsList.push(t.text);
    });
    var value = tagsList.join();
    tagOut.setAttribute('value', value);
    console.log(tagsList);
}

function tagEditor() { 
    var input = document.getElementById('tagin');

    var tag = input.value;
    if (tag.includes(',')) {
        tag = tag.replace(',', '');
        console.log(tag);
        input.value = "";
        addTag(tag);
    }
}



