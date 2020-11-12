# Purpose

This console application is a gateway to be used with a Lyrics projection software and vMix production and streaming software (see : https://www.vmix.com/).
The idea is to retrieve only the text of the current slide of the Lyrics projection software and send it to a Title input in vMix.
Then the layout will be done on vMix on the Text Input (not on the Lyrics projection software that only manage the layout for the projection).

Currently, only OpenLP is supported (see: https://openlp.org/), but it can be easily extended to other...

To do so, LyricsTovMix call the API of the lyrics software in order to get the current slide text then forward that text to the vMix API.

# Setting up OpenLP

1. Get the IP and port number in OpenLP: URL found in Settings/Configure OpenLP/Remote/Stage view URL

# Setting up vMix

1. Enable Remote access (Settings/Web Controller/Enabled), get the IP and port number
2. Add a Title input (Add Input/Title XAML/Text Text HD)
3. Note the Title input number

# Install

LyricsTovMix is portable: just unzip the archive.


# Usage

1. Update AppSettings.json file with your own IPs, port numbers and input number (you should have noted those settings earlyer ;-) )
2. Launch LyricsTovMix.exe
3. Change the current slide on OpenLP, it should appear in vMix!
4. Customize your lower third layout in vMix to have the overlay you want for your live Show!

Note:

LyricsTovMix doesn't consume a lot of CPU and memory but it could be better to run it on the computer that run the Lyrics projection software to let maximum resources to the vMix computer... but that's up to you.

# Troubleshouting

My slide cannot be sent to vMix : check if the computer that run LyricsTovMix can access:
* to vMix : open the Web controller, URL found in Settings/Web Controller/Enabled in your browser
* to OpenLP : open the stage display, URL found in Settings/Configure OpenLP/Remote/Stage view URL

If both pages can be open on the computer that run LyricsTovMix, the problem is due to the configuration of LyricsTovMix.
If those pages can't be open, check your network/firewall settings, vMix, OpenLP, etc. settings in order to correct the problem.

# Idea

Inspired by: https://github.com/cgarwood/ProPresenter-vMix
Thanks for the great idea!

# ToDo

* Currently LyricsTovMix doesn't support API authentication on OpenLP and vMix.
* Add a parameter in order to truncate text if there is too much lines.