# Code Counter

Console application which counts the total number of lines in a directory

## Directory exclusion
Files in folders which are excluded will not have their lines counted

## Counting of specific file types
Will only count files which have the same extension provided in the file extension list, file extensions can be separated with any character or no character at all (ex: .c.xaml / .cs+.xaml)

## Write to file
Optional mode to output results to an output.log file in the directory where the executable resides.
The output file shows the files which had their lines counted along with the lines of each file as well as the total number of lines and file with the most and least lines.
