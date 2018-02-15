# WinToolHAB - Windows Backup/Restore/Update Tool for OpenHAB

## Disclaimer 

**The application hasn't been thoroughly tested. Use at your own risk. I am not responsible for any damage that may arise from using this application.**

## Prerequisites

This applicaton requires Microsoft .NET Framwork 4.6.1. You can download it following this [link](https://www.microsoft.com/en-us/download/confirmation.aspx?id=49981, "Microsoft .NET Framework 4.6.1").

## Installation

Download an archive from the Release page and extract it to a folder, or clone/download a source and build it using Microsoft Visual Studio.

## Configuration

### General

- OpenHAB started as - depending on your installation, you can choose between:
  * Windows Service 
  * Windows Application
    
- Service name - if OpenHAB is started as Windows Service, this should be populated with a name of the OpenHAB service you're running (e.g. OpenHABService)

- OpenHAB path - root path of the OpenHAB folder (e.g. C:\OpenHAB)

### Backup

- Backup type - choose the type of backup you wish to make:
  * Full backup - backup whole **OpenHAB** folder (configured in OpenHAB path field on General page) with all subfolders
  * Configuration backup - backup **conf** and **userdata** folders only
  
- Backup path -  choose a destination folder for a backup archive using an open button (..) or enter a full path to a destination folder

- Backup management - choose additional options for easier backup management (settings are kept separately for each Backup type):
  * Delete old backups - if checked, upon creating new backup, application will delete oldest backups (number of backups kept depends on the Keep last setting)
  * Keep last - number of backups kept (including the backup being created)
  
### Restore

- Restore backup file - choose a backup archive you wish to restore using an open button (..) or enter a full path to a backup archive

### Update

- Update path - choose a folder containing OpenHAB update files using an open button (..) or enter a full path to a folder containing OpenHAB update files - in case of Online update, this folder is used as a download destination

- Update type - choose the update type you wish to use:
  * Online update - download an update from a predefined location 
  * Local update - update using a local update file 
  
- Update URL - displayed when Online update option is being used - URL with an update file name and extenstion (e.g. for an OpenHAB nighly you could use https://openhab.ci.cloudbees.com/job/openHAB-Distribution/lastSuccessfulBuild/artifact/distributions/openhab/target/openhab-2.3.0-SNAPSHOT.zip)

- Update file - displayed when Local update option is being used - choose an OpenHAB update file using an open button (..) or enter a full path to an OpenHAB update file
  
- Before updating - choose pre-update operation:
  * Do not create backup - No pre-update operations - only OpenHAB update is being performed
  * Create full backup - Creates full backup using settings from the Backup page and performs OpenHAB update
  * Create configuration backup - Creates configuration backup using settings from the Backup page and performs OpenHAB update
  
## Additional notes

- Actions are performed by clicking the button on a respective page
- Before operations are performed, settings validation takes place
- List of files that should be deleted during an OpenHAB update is located in DeleteList.dat. This file can be edited using any text editor and it supports wildcard characters (? and *)
- In case of Restore and Update operations, if OpenHAB is started as a Windows Service and a correct service name is set, application will shut down OpenHAB service, perform chosen operation(s), and, after finishing, start OpenHAB service
- If OpenHAB is started as a Windows Application, it should be stopped before performing Restore or Update operations. In case the application finds **java** and **cmd** processes being run simultaneously, it will stop operation execution and show a message, until OpenHAB is stopped
- When performing a backup operation while OpenHAB is running, some files will be locked and cannot be added to an archive. Application will display these files as an error (red), but a backup archive will be created (without locked files)

## Donations

This application is available for free under the GPL license. If you use the application, and would like to donate, feel free to send any amount through paypal. 

Note: Since standard Donate option is not available on my PayPal account this is a workaround solution.

[![Donate](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=CCZRY3C8RXSRW&lc=BA&item_name=Donation%20%2d%20WinToolHAB&item_number=4&button_subtype=services&currency_code=EUR&bn=PP%2dBuyNowBF%3abtn_paynowCC_LG%2egif%3aNonHosted)

## License

Software licensed under GPL version 3 available on http://www.gnu.org/licenses/gpl.txt.
