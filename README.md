# A00446098_MCDA5510

This program does following things:
•	It goes into each folder of given directory path and collects all files in the way and end of traversal.

•	At the end of current namespace we have declared global vars which are 2 lists, each one to store valid and skipped rows of csvfiles as  elements. 

•	In the main function we give filepaths to save and write/append rows of csv files and give log data. First we write column names into valid rows file using streamwriter. 

•	We also create an object of dirwalker class which will be defined further. Objects of this class will have a walk function which will go into each folder and see if there are more folders. Then it enters those folders and does same again. If it only contains files at some level. it collects paths of the files into a string array.Then for each file we create a textfield parser object to create a parser to traverse through the rows of the file delimited by comma.  

•	It then goes into each file(csv) and runs a while loop such that for as long as we have not reached end of file, each row is considered using parser.

•	each row has set count=0

•	each row is then looped for each column.

•	Validation:
•	If the column is ="" i.e., blank or if the number of cols in the row is <10 which is number of columns that should be present, then this is considered incomplete row.

•	this row is given value count=1

•	if at current row count=1 , add the row to global variable list "valid". else add it to global variable list "skipped".  

•	If there is an exception in traversing through the csv-file we catch it in catch(IOException ioe).


•	Then we iterate over the 2 global arrays and take each element/row and write to write.txt and skip.txt using streamwriter. 

•	After 2 files have been created, we calculate their length and put into log file.

•	We start the stop watch at beginnng of main function and stop at after writing to log and other files and then calculate time taken to run the files and write it to log.

