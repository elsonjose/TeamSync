#!/bin/bash
if [ $# -eq 2 ]; then
    readme_file=$"readme.md"
    timestamp=$(date +%Y%m%d%H%M%S)
    file_name=docs/$timestamp'_'$1'.md'
    if [ ! -d "docs" ]; then
        mkdir docs
    fi
    echo >> $file_name && echo "File '$file_name' generated"
    echo "## $2" >> $file_name
    if [ ! -f $readme_file ]; then
        echo >> $readme_file
    fi
    echo "- [$2]($file_name)" >> $readme_file && echo "Readme updated"
else
    echo "File name and short description required"
fi
