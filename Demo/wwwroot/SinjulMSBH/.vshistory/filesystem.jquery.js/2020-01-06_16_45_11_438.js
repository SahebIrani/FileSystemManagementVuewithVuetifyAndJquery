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

                            var strTabClass = `p-2 my-1 mx-0`;
                            var strTabStyle = `margin-left:${tab}px;margin-top:10px;`;

                            var name = data[i].name;
                            var size = data[i].size;
                            var title = 'title="Updated ' + data[i].lastWriteTime;

                            if (size !== undefined) {
                                title += '. Size ' + size;
                            }

                            title += '"';

                            if (data[i].isFile) {

                                var extension = getIconFromExtension(data[i].id);

                                const fileResult = `<div id=${id}${index} class="${strTabClass}" style="${strTabStyle}">
                                                        <span ${strTabStyle}>
                                                          <i class="${extension} mr-4"></i>
                                                          ${name}
                                                        </span>
                                                     </div>`
                                    ;

                                obj.append(fileResult);
                            }
                            else {

                                var onClick = '';
                                var style = '';

                                if (data[i].hasChilds) {
                                    onClick = `onclick="javascript: fileSystem.build('${data[i].id}', '${id}', ${index}, ${(tab + 10)})"`;
                                    style = 'style="cursor:pointer"';
                                }

                                const folderResult = `<div id=${id}${index} class="${strTabClass} border p-2" style="${strTabStyle} cursor:pointer;">
                                                            <span ${title} ${style} ${onClick}>
                                                                   <i id="${i}${index}" class="far fa-folder mr-4"></i>
                                                                   ${name}
                                                            </span>
                                                      </div>`
                                    ;

                                obj.append(folderResult);
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
                case 'rar': extension = 'far fa-file-archive'; break;
                case 'zip': extension = 'far fa-file-archive'; break;
                case 'pdf': extension = 'far fa-file-pdf'; break;
                case 'docx': extension = 'far fa-file-word'; break;
                case 'doc': extension = 'far fa-file-word'; break;
                case 'xlsx': extension = 'far fa-file-excel'; break;
                case 'xls': extension = 'far fa-file-excel'; break;
                case 'csv': extension = 'far fa-file-excel'; break;
                case 'html': extension = "fab fa-html5"; break;
                case 'cs': extension = "fab fa-microsoft"; break;
                case 'sln': extension = "fab fa-microsoft"; break;
                case 'ts': extension = 'fab fa-js'; break;
                case 'json': extension = 'fas fa-cogs'; break;
                case 'js': extension = 'fab fa-js'; break;
                case 'cshtml': extension = "fab fa-html5"; break;
                case 'csproj': extension = 'file-code'; break;
                case 'dll': extension = 'file-fill'; break;
                case 'bmp': extension = 'far fa-file-image'; break;
                case 'png': extension = 'far fa-file-image'; break;
                case 'gif': extension = 'far fa-file-image'; break;
                case 'jpg': extension = 'far fa-file-image'; break;
                case 'jpeg': extension = 'far fa-file-image'; break;
                default: extension = 'far fa-file';
            }

            return extension;
        };

    return {
        build: build
    };

}();