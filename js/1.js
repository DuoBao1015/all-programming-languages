   fileinput.onchange = () => {
            //console.log('dddd')
            var files = fileinput.files
            let imgDOMArray = new Array(files.length)
            let reader = []
            let thumbPic = []
            progressDOM = document.getElementById('progress-img')
            for (let i = 0; i < files.length; i++) {
                reader[i] = new FileReader()
                thumbPic[i] = document.createElement('div')
                imgDOMArray[i] = document.createElement('img')
                imgDOMArray[i].file = files[i]
                thumbPic[i].className = 'thumbPic'
                thumbPic[i].appendChild(imgDOMArray[i])
                previewDOM.appendChild(thumbPic[i])
                reader[i].readAsDataURL(files[i])
                reader[i].onload = (img => {

                    return e =>img.src = e.target.result
                    
                })(imgDOMArray[i])

            }
        }

                var aUpload = document.querySelector('.selectImg')
        var button = document.querySelector('#upload')
        var fileinput = document.getElementById('file')
        button.onclick = uploadFile
         function uploadFile() {
            //  console.log('ddd')
            var xhr = new XMLHttpRequest()
            var formdata = new FormData()

            var files = fileinput.files
            if (!files[0]) {
                alert('Please select upload content first!')
                return
            }

            var progress = document.querySelector('progress')
            for (let i = 0; i < files.length; i++) {
                formdata.append('imgfile', files[i], files[i].name)
            }
            xhr.open('POST', '/uploadimg')
            xhr.onload = () => {
                if (xhr.status === 200 && xhr.responseText === 'success') {
                    previewDOM.innerHTML = ''
                    xhr = null
                    alert('Content uploaded successfully!')
                }
            }
            xhr.send(formdata)
            xhr.upload.onprogress = e => {
                if (e.lengthComputable) {
                    var progressWrap = document.querySelector('.progress')
                    progressWrap.style.display = "flex"
                    var percentComplete = e.loaded / e.total * 100
                    progress.value = percentComplete

                    if (percentComplete >= 100) {
                        progress.value = 0
                        progressWrap.style.display = "none"
                    }
                }
            }

        }