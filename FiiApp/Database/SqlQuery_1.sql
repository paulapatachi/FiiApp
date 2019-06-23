

--SELECT TOP 1 * FROM Student
--ORDER BY NEWID()


DECLARE @curs_id int
DECLARE @stud_id int
DECLARE @year int
DECLARE @exam_day date
DECLARE @grade int
DECLARE lista_studenti CURSOR FOR SELECT Id FROM Student WHERE ID>5;	


OPEN lista_studenti
FETCH NEXT FROM lista_studenti INTO @stud_id

WHILE @@FETCH_STATUS = 0    
BEGIN   
	
	DECLARE lista_cursuri CURSOR  FOR SELECT DISTINCT CourseId, AcademicYear, [Date] FROM FinalGrade;
	OPEN lista_cursuri 
	FETCH NEXT FROM lista_cursuri INTO @curs_id, @year, @exam_day
	WHILE @@FETCH_STATUS = 0   
	BEGIN
		SET @grade = ABS(CHECKSUM(NEWID()) % 6) + 5
		--print '  ----------------------------------    ' + CAST(@stud_id as varchar(10))
		--print CAST(@stud_id as varchar(10)) + ' __ ' + CAST(@curs_id as varchar(10)) + ' __ ' + CAST(@year as varchar(10)) + ' __ ' +    CAST(@grade as varchar(10))   + ' __ ' + CAST(@exam_day as varchar(10))
		--print '   ' + CAST(@curs_id as varchar(10)) + '   -----   '+  CAST(@year as varchar(10)) + '   ----   ' +  CAST(@exam_day as varchar(10))

		INSERT INTO FinalGrade
           ([StudentId] ,[CourseId] ,[AcademicYear] ,[Grade] ,[Date])
     VALUES (@stud_id ,@curs_id ,@year  ,@grade  ,@exam_day)

		FETCH NEXT FROM lista_cursuri INTO @curs_id, @year, @exam_day
	END
	CLOSE lista_cursuri;    
	DEALLOCATE lista_cursuri;  

	
  
      
    FETCH NEXT FROM lista_studenti INTO @stud_id


    
   
END     
CLOSE lista_studenti;    
DEALLOCATE lista_studenti;  

