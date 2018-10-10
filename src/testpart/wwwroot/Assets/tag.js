//var app = angular.module('plunker', ['ngTagsInput']);

//app.controller('MainCtrl', function($scope, $http) {
//  $scope.tags = [
//    { text: 'Tag1' },
//    { text: 'Tag2' },
//    { text: 'Tag3' }
//  ];
//});
// @ts-check

function tagEditor() {
    var tags = [];
    var input = document.getElementById('tagin');
    var showTags = document.getElementById('showTags');
    var tagOut = document.getElementById('tagout');
    var tag = input.value;
    if (tag.includes(',')) {
        tag = tag.replace(',', '');
        console.log(tag);
        input.value = "";
        addTag(tag);
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

        tags.push(tag.text);

        showTags.appendChild(tag.element)
        tagOut.setAttribute('value', tagOut.getAttribute('value') + tag.text);
    }

    function removeTag(index) {
        let tag = tags[index];
        tags.splice(index, 1)
        showTags.removeChild(tag.element);
    }

}

//    let enteredTags =  .value.split(',');
//    if (keyCode === 32 || keyCode === 188) {

//    }
//});


function initializeTagEditor(tagsInput) {
    [].forEach.call(document.getElementsByClassName('tags-input'), function (el) {
        let hiddenInput = document.createElement('input'),
            mainInput = document.createElement('input'),
            tagInput = document.getElementById('tagin'),
            tags = [];            

        var tagx = tagsInput;
        console.log(tagx);

        hiddenInput.setAttribute('type', 'hidden');
        hiddenInput.setAttribute('name', el.getAttribute('data-name'));

        mainInput.setAttribute('type', 'text');
        mainInput.setAttribute('asp-for', 'Tags')
        mainInput.classList.add('main-input');
        mainInput.addEventListener('input', function () {
            let enteredTags = mainInput.value.split(',');
            if (enteredTags.length > 1) {
                enteredTags.forEach(function (t) {
                    let filteredTag = filterTag(t);
                    if (filteredTag.length > 0) {
                        addTag(filteredTag);
                    }
                });
                mainInput.value = "";
            }
        });


        mainInput.addEventListener('keydown', function (e) {
            let keyCode = e.which || e.keyCode;
            if (keyCode === 8 && mainInput.value.length === 0 && tags.length > 0) {
                removeTag(tags.length - 1);
            }
        });

        el.appendChild(mainInput);
        el.appendChild(hiddenInput);


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

            el.insertBefore(tag.element, mainInput);

            refreshTags();
        }

        function removeTag(index) {
            let tag = tags[index];
            tags.splice(index, 1)
            el.removeChild(tag.element);
            refreshTags();

        }

        function refreshTags() {
            let tagsList = []
            tags.forEach(function (t) {
                tagsList.push(t.text);
            });
            hiddenInput.value = tagsList.join(',');
        }

        function filterTag(tag) {
            return tag.replace(/[^\w -]/g, '').trim().replace(/\W+/g, '-');
        }
    });
}

