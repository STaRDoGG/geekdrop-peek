# ![YooHoo ...](https://github.com/STaRDoGG/geekdrop-peek/blob/master/GeekDrop%20Peek/Images/GeekDrop%20Peek.png)   GeekDrop Peek #

**Extract &amp; View Strings in Files via Windows' Context-Menu.**

**Tip:** If you want to skip reading all of this mumbo-jumbo, and just download the app right now, you can grab the compiled versions right here: https://github.com/STaRDoGG/geekdrop-peek/releases

There's a 32 Bit version and a 64 Bit version for you to choose from.



## Like GeekDrop Peek and wanna donate? ##

Why, thank ya kindly! You can do just that via Paypal! http://geekdrop.com/x/peek-donations



## What in bejesus this? ##

Back in 1996 a developer created an excellent, tiny little, but immensely useful extension entitled "Peek" for short, or "Peek Shell Extension" for long. It extracted any strings it found within any file you wanted to sniff into. Great for looking for malicious programs, and what-not. It was around for years and years without issue until just the last Version (Windows 7) or two (Vista) in which it started to struggle in the compatibility department.

Unfortunately, many people can no longer use Peek on Windows 7+, and the original developer of Peek has lost the source code to it, and has decided that rather than writing a newer version again from scratch, to just let the Peek Shell Extension slowly fade away into oblivion.

You can read the full story on the developer's (he's a really nice guy actually) blog here: http://www.loramel.net/blender_minutes/peek

Alas, that is UNacceptable to us die-hard Peek lovers ;) and this is my attempt at creating a modern version of Peek which is compatible with more modern (as well as old) versions of Windows.

Actually, rather than writing one from scratch myself, I've decided to just made use of what's already out there and sort of "stitch" things together into basically a Peek clone. No sense in re-inventing the wheel, right? So, the only credit I can accept is my work in bridging things together (this app), which apparently no one else has to date. Certainly, a slightly more elegant way could (and should) be done, i.e. write an actual shell extension again, but the end visual and usability result in mine is still the same. Once you install this it'll behave exactly the same as if it were a true, compiled shell extension, i.e. the original Peek Shell Extension we all knew and loved.



## Installation? (we dun need no steenking installation!) ##

This is a VERY easy app to use, and is designed to be 100% portable so that you can just move a single file wherever you want it; any folder, no setup program needed, it can be copied to a USB stick, whatever ya want (there are a couple requirements however, see below). To use it just follow the steps below.

**Requirements:**
* .NET Framework 4.5 (usually already installed in Windows if updated)
* Sysinternals "Strings" (More info below) (homepage: http://technet.microsoft.com/en-us/sysinternals/bb897439.aspx)

The "engine" behind this all relies on Sysinternal's "Strings" program. It's what does the actual string extraction for us. Maybe later I'll take the time to write my own, but for now there seems to be no reason to since theirs is excellent. Btw, all full credit, etc. for that is theirs, not trying to step on any usage rights.

However, their license doesn't allow us to actually include it in this package, or on our website, so we have to follow their rules. To make things smoother for us though, I've created a built-in downloader that will fetch the latest version of Strings and unzip it, and check each time the app is run, for a newer version. If a newer version is found, it will also give you the option and ability to fetch, unzip and install it with a single click.

**1.)** Simply place GeekDrop Peek.exe anywhere on your computer or external USB drive that you want to keep it, then double-click it.

 **a)** The first time it's run, it'll first check if you have Strings.exe in the same folder as this app (meaning it's "installed" for lack of a better term), if not, it'll download it and unzip it to the same folder for you.

 **b)** (Default): Next, it'll look to see if you have the "Shell Extension" installed. I use the term "Shell Extension" loosely, since it's not a true Shell Extension, it's just an addition to your Windows Context Menu via the Registry, so that you can right-click on any file, and click "GeekDrop Peek" to extract the strings from the file you selected.

 **c)** (Advanced): You can choose NOT to install the Windows context menu extension to call GeekDrop Peek from, and call it via a direct command-line call. This is useful if you know exactly what you're doing and would like to call Peek via another method; such as another Menu Utility, maybe a batch file, or whatever comes to mind. In order to do that, just call GeekDrop Peek.exe  with the file(s) full path as a parameter. If there are spaces in the path at all, wrap the entire path in quotes. Example: "C:\Windows\GeekDrop Peek.exe" "D:\Program Files\Stuff\File to Peek Into.exe"


**2.)** All done!

The program will exit. Now whenever you want to sniff around inside of any file just right-click on the file in Explorer (or your favorite Explorer replacement) and click "GeekDrop Peek". (Or if you chose the advanced option, call it however you set it up.) It'll extract any strings it finds in the file and load up your Windows Notepad.exe with the results, (or whichever other program you have associated by default to open .txt files).



## Uninstallation ##

To uninstall it, just manually run GeekDrop Peek.exe again by double-clicking it, and click the Uninstall button. It'll remove the Windows Context Menu item, and delete the Strings.exe file. Good as new! Want to re-install it? Maybe something broke? Just run it again and install.



## Roadmap and Todo's ##

* MAYBE I'll replace Strings with my own code. I've already got it mostly done anyway, who knows.
* Maybe add/replace opening in the external viewer with an internal viewer, with some highlighting options.
* Maybe add an option to select your own external viewer instead of using Notepad (or whatever other program you have set to open .txt files).
* Maybe add ability to use custom parameters instead of the default ones, since Strings has several available. The current default ones used in this app offer the same result as the original Peek extension.



## Other Notes Worth a Mention ##

* I've made sure to keep this completely compatible with the original Peek extension so that they don't conflict, you can have both installed and usable at the same time if you wish, assuming the original Peek extension is working on your system (probably before Windows 7).



## Bugs? ##

Tested to be working fine on everything except some setup type programs, in which case it simply runs the setup program as if Strings.exe wasn't even called. Pretty sure this is a Strings.exe bug.

Anything else, let me know in the usual Issues area, here.



## Screenshots ##

**First time ya run it, you'll see this, prompting you to install the Strings "engine".**

![First time ya run it, you'll see this, prompting you to install the Strings "engine".](https://github.com/STaRDoGG/geekdrop-peek/blob/master/GeekDrop%20Peek/Images/Screenshots/GeekDrop-Peek-Installation-Step1.jpg)

**Second step, you're prompted to install the context-menu item.**

![Second step, you're prompted to install the context-menu item.](https://github.com/STaRDoGG/geekdrop-peek/blob/master/GeekDrop%20Peek/Images/Screenshots/GeekDrop-Peek-Installation-Step2.jpg)

**That's it! Now you're just told how to use it.**

![That's it! Now you're just told how to use it.](https://github.com/STaRDoGG/geekdrop-peek/blob/master/GeekDrop%20Peek/Images/Screenshots/GeekDrop-Peek-Installation-Step3.jpg)

**The main window when no engine or context-menu item is installed. From here you basically just click that "Install" button.**

![The main window when no engine or context-menu item is installed. From here you basically just click that "Install" button.](https://github.com/STaRDoGG/geekdrop-peek/blob/master/GeekDrop%20Peek/Images/Screenshots/GeekDrop-Peek-Install.jpg)

**Screenshot showing the context-menu item you'll click on when you have a file(s) selected in Windows.**

![Screenshot showing the context-menu item you'll click on when you have a file(s) selected in Windows.](https://github.com/STaRDoGG/geekdrop-peek/blob/master/GeekDrop%20Peek/Images/Screenshots/GeekDrop-Peek-Context-Menu.png)

**An example of the GeekDrop Peek output after "peeking" into an "unknown" file, to look around for anything suspicious. Oops! Look at that! We found some stuff! We definitely don't wanna be running THAT on our system!**

![An example of the GeekDrop Peek output after "peeking" into an "unknown" file, to look around for anything suspicious. Oops! Look at that! We found some stuff! We definitely don't wanna be running THAT on our system!](https://github.com/STaRDoGG/geekdrop-peek/blob/master/GeekDrop%20Peek/Images/Screenshots/GeekDrop-Peek-Example-Output.png)

**The 'About' screen. Pretty, ain't it?**

![The 'About' screen. Pretty, ain't it?](https://github.com/STaRDoGG/geekdrop-peek/blob/master/GeekDrop%20Peek/Images/Screenshots/GeekDrop-Peek-About.jpg)

**Want to uninstall GeekDrop Peek? Simple, just click that Uninstall button and the context-menu item will be deleted as well as the Strings engine, leaving your system just as it was before you installed it.**

![Want to uninstall GeekDrop Peek? Simple, just click that Uninstall button and the context-menu item will be deleted as well as the Strings engine, leaving your system just as it was before you installed it.](https://github.com/STaRDoGG/geekdrop-peek/blob/master/GeekDrop%20Peek/Images/Screenshots/GeekDrop-Peek-Uninstall.jpg)

**See?**

![See?](https://github.com/STaRDoGG/geekdrop-peek/blob/master/GeekDrop%20Peek/Images/Screenshots/GeekDrop-Peek-Uninstallation.jpg)

**Even better, how about a quick demonstration video? (_Click below image to watch on YouTube_)**

[![GeekDrop Peek Demonstration Video](https://img.youtube.com/vi/pAPLaC5Q3Fg/0.jpg)](http://youtu.be/pAPLaC5Q3Fg)

## Other Links ##

The "home page" of GeekDrop Peek, is right here, don't be a stranger!: http://geekdrop.com/x/peek



## Changelog ##

* Version 1.1
	* Added label addition to indicate if you're using the 32 Bit or 64 Bit version. If using x64 it'll show, otherwise it'll appear the same as usual.
	* Added ability to choose whether to install the Shell Extension into Windows' Context-menu, or an advanced ability to just call GD Peek via a command-line.
	  This allows for doing things such as calling GD Peek with other utilities. For example, FileMenu Tools: http://www.lopesoft.com/en/filemenutools
	* Added label(s) to indicate which method the user chose to call GD Peek.
	* Removed redundant ReadMe.txt file.
	* Updated About.rtf which displays from a resource, in the About screen.
	* Changed the button from displaying "Install/Uninstall Shell Extension" to "Install/Uninstall GeekDrop Peek" since I added the newer advanced calling option.
* Version 1.0
	* First release. Hello World!