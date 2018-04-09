#!/usr/bin/env bash

wget --quiet http://51.144.52.98/s/NkQcDLKb6CBgL6E/download -P $APPCENTER_SOURCE_DIRECTORY/PlacingObjects/Resources/VGG16.mlmodelc/ -O model.espresso.weights
cat $APPCENTER_SOURCE_DIRECTORY/PlacingObjects/Resources/VGG16.mlmodelc/