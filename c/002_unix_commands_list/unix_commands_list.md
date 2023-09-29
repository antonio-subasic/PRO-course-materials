by Antonio Subašić

# Unix-Commands

### cd

- short for **change directory**
- changes the directory in which the user is currently in
- e.g.: `cd /home/antonio-subasic/programming`

### cat

- short for **concatenate**
- displays the contents of a file
- e.g.: `cat /home/antonio-subasic/programming/myapp.c`

### chmod

- short for **change mode**
- changes the access rights of files and directories
- e.g.: `chmod 755 /home/antonio-subasic/programming/myapp.c`

### cmp

- short for **compare**
- compares the contents of two files
- e.g.: `cmp /home/antonio-subasic/programming/myapp.c /home/antonio-subasic/programming/myapp_backup.c`

### diff

- short for **difference**
- compares the contents of two files and displays the differences between them
- e.g.: `diff /home/antonio-subasic/programming/myapp.c /home/antonio-subasic/programming/myapp_backup.c`

### cp

- short for **copy**
- copies files and directories
- e.g.: `cp /home/antonio-subasic/programming/myapp.c /home/antonio-subasic/programming/myapp_backup.c`

### head

- displays the first few lines of a file
- e.g.: `head /home/antonio-subasic/programming/myapp.c`

### ls

- short for **list**
- lists the contents of a directory
- e.g.: `ls /home/antonio-subasic/programming`

### mkdir

- short for **make directory**
- creates a new directory
- e.g.: `mkdir /home/antonio-subasic/programming/new_directory`

### more

- displays the contents of a file one page at a time
- e.g.: `more /home/antonio-subasic/programming/myapp.c`

### less

- displays the contents, but allows the user to scroll up and down through the file
- e.g.: `less /home/antonio-subasic/programming/myapp.c`

### man

- short for **manual**
- displays the manual page for a command
- e.g.: `man less`

### mv

- short for **move**
- moves files and directories
- e.g.: `mv /home/antonio-subasic/programming/myapp.c /home/antonio-subasic/programming/myapp_backup.c`

### pwd

- short for **print working directory**
- displays the current working directory
- e.g.: `pwd`

### rm

- short for **remove**
- removes files and directories
- e.g.: `rm /home/antonio-subasic/programming/myapp_backup.c`

### rmdir

- short for **remove directory**
- removes a directory
- e.g.: `rmdir /home/antonio-subasic/programming/new_dir`

### tail

- displays the last few lines of a file
- e.g.: `tail /home/antonio-subasic/programming/myapp.c`

### touch

- creates a new file
- e.g.: `touch /home/antonio-subasic/programming/new_app.c`

### ps

- short for **process status**
- displays information about running processes
- e.g.: `ps -A`

### sort

- sorts the lines of a file
- e.g.: `sort /home/antonio-subasic/programming/myapp.c`

### find

- searches for files and directories
- e.g.: `find /home/antonio-subasic/programming -name "myapp.c"`

### grep

- searches for patterns in files
- e.g.: `grep "int main()" /home/antonio-subasic/programming/myapp.c`

### passwd

- changes the user's password
- e.g.: `passwd`

### su

- short for **substitute user**
- switches to a different user account
- e.g.: `su root`

### sudo

- short for **superuser do**
- allows the user to run commands with root privileges
- e.g.: `sudo apt install build-essential`

### kill

- sends a signal to a process
- e.g.: `kill -9 1234`

### who

- displays a list of logged-in users
- e.g.: `who`

### wc

- short for **word count**
- counts the number of lines, words, and characters in a file
- e.g.: `wc /home/antonio-subasic/programming/myapp.c`

### cut

- extracts fields from a file
- e.g.: `cut -d "," -f 1 file.csv`

### date

- displays the current date and time
- e.g.: `date`

### du

- short for **disk usage**
- displays the amount of disk space used by files and directories
- e.g.: `du -h`

### uniq

- short for **unique**
- removes duplicate lines from a file
- e.g.: `uniq /home/antonio-subasic/programming/myapp.c`

### shutdown

- shuts down the system
- e.g.: `shutdown now`

### sleep

- pauses execution of the script for a specified number of seconds
- e.g.: `sleep 5`

### echo

- displays a message on the console
- e.g.: `echo "Hello, world!"`

### gedit

- opens the text editor gedit
- e.g.: `gedit /home/antonio-subasic/programming/myapp.c`
