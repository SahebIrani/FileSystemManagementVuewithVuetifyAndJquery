var fileSystem = function () {

    var index = 0,

        build = function (dir, id, objIndex, tab) {

            $.getJSON('GetAllFileSystem?fullName=' + dir + '&formatterName=Humanizer', (data, status) => {

                if (status === 'success') {
                    var obj = $('#' + id + objIndex);

                    $('#i' + objIndex).toggleClass('fa-folder-open');

                    if (obj.children('div').length > 0) {
                        obj.children('div').toggle();
                    }
                    else {
                        for (var i = 0; i < data.length; i++) {

                            index = index + 1;

                            var strTabClass = `border p-4 my-4 mx-0`;
                            var strTabStyle = `margin-left:${tab}px;`;

                            var name = data[i].name;
                            var size = data[i].size;
                            var title = 'title="Updated ' + data[i].lastWriteTime;

                            if (size !== undefined) {
                                title += '. Size ' + size;
                            }

                            title += '"';

                            if (data[i].isFile) {

                                var extension = getIconFromExtension(data[i].id);

                                const appendResult = `<div id=${id}${index} class="${strTabClass}" style="${strTabStyle}">
                                                        <span ${strTabStyle}>
                                                          <i class="far fa-${extension} mr-4"></i>
                                                        </span>
                                                     </div>`
                                    ;

                                obj.append(appendResult);
                            }
                            else {

                                var onClick = '';
                                var style = '';

                                if (data[i].hasChilds) {

                                    onClick = `onclick = javascript: fileSystem.build(${data[i].id}, ${id}, ${index}, ${(tab + 10)})`;

                                    style = 'style="cursor:pointer"';
                                }

                                const appendResult = `<div id=${id}${index} clas="${strTabClass}" style="${strTabStyle}" ${onClick}>
                                                            <span ${title} ${style} ${onClick}>
                                                                   <i id="${i}${index}" class="far fa-folder mr-4"></i>
                                                            </span>
                                                      </div>`
                                    ;

                                obj.append(appendResult);
                            }
                        }
                    }
                }
            });
        },

        getIconFromExtension = function (file) {
            var segs = file.split('.');
            var extension = segs[segs.length - 1];
            switch (extension.toLowerCase()) {
                case 'rar':
                case 'zip': extension = 'file-archive'; break;
                case 'pdf': extension = 'file-pdf'; break;
                case 'docx':
                case 'doc': extension = 'file-word'; break;
                case 'xlsx':
                case 'xls': extension = 'file-excel'; break;
                case 'html':
                case 'cs':
                case 'sln':
                case 'ts':
                case 'js':
                case 'cshtml':
                case 'csproj': extension = 'file-code'; break;
                case 'dll': extension = 'file-fill'; break;
                case 'bmp':
                case 'png':
                case 'gif':
                case 'jpg':
                case 'jpeg': extension = 'file-image'; break;
                default: extension = 'file';
            }

            return extension;
        };

    return {
        build: build
    };

}();