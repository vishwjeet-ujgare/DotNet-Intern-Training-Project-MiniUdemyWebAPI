-- Create database MiniUdemyDB;
-- Drop database MiniUdemyDB;
	use MiniUdemyDB
-- ================================================================================ --
-- =============================USER========================================= --
-- ================================================================================ --


-- Insert dummy users
INSERT INTO Users (FirstName, Email, Password, CreatedAt, UpdatedAt, IsActive, IsDeleted)
VALUES
('John1', 'john1@example.com', 'Pass@123', GETUTCDATE(), GETUTCDATE(), 1, 0),
 
('Jane1', 'jane1@example.com', 'Jane@1234', GETUTCDATE(), GETUTCDATE(), 1, 0),
 
('Alice1', 'alice1@example.com', 'Alice@5678', GETUTCDATE(), GETUTCDATE(), 1, 0),
 
('Bob1', 'bob1@example.com', 'Bob@321', GETUTCDATE(), GETUTCDATE(), 1, 0),
 
('Charlie1', 'charlie1@example.com', 'Char@789', GETUTCDATE(), GETUTCDATE(), 1, 0);


INSERT INTO Users (FirstName, Email, Password, CreatedAt, UpdatedAt, IsActive, IsDeleted)
VALUES
('John', 'john@example.com', 'Pass@123', GETUTCDATE(), GETUTCDATE(), 1, 0),
('Jane', 'jane@example.com', 'Jane@1234', GETUTCDATE(), GETUTCDATE(), 1, 0),
('Alice', 'alice@example.com', 'Alice@5678', GETUTCDATE(), GETUTCDATE(), 1, 0),
('Bob', 'bob@example.com', 'Bob@321', GETUTCDATE(), GETUTCDATE(), 1, 0),
('Charlie', 'charlie@example.com', 'Char@789', GETUTCDATE(), GETUTCDATE(), 1, 0),
('Dave', 'dave@example.com', 'Dave@456', GETUTCDATE(), GETUTCDATE(), 1, 0),
('Eve', 'eve@example.com', 'Eve@654', GETUTCDATE(), GETUTCDATE(), 1, 0),
('Frank', 'frank@example.com', 'Frank@987', GETUTCDATE(), GETUTCDATE(), 1, 0),
('Grace', 'grace@example.com', 'Grace@321', GETUTCDATE(), GETUTCDATE(), 1, 0),
('Hank', 'hank@example.com', 'Hank@654', GETUTCDATE(), GETUTCDATE(), 1, 0);


-- ================================================================================ --

-- Example: Assigning roles to users
	-- Assuming RoleId 1 = Admin, 2 = Instructor, 3 = Student
 
	-- UserId 1 (John) as Admin
INSERT INTO UserRoles (UserId, RoleId, CreatedAt, UpdatedAt)
VALUES 
    (1, 1, GETUTCDATE(), GETUTCDATE()),
    (2, 2, GETUTCDATE(), GETUTCDATE()),
    (3, 3, GETUTCDATE(), GETUTCDATE()),
    (4, 3, GETUTCDATE(), GETUTCDATE()),
    (5, 2, GETUTCDATE(), GETUTCDATE());


INSERT INTO UserRoles (UserId, RoleId, CreatedAt, UpdatedAt)
VALUES 
    (6, 1, GETUTCDATE(), GETUTCDATE()),
    (7, 2, GETUTCDATE(), GETUTCDATE()),
    (8, 3, GETUTCDATE(), GETUTCDATE()),
    (9, 3, GETUTCDATE(), GETUTCDATE()),
    (10, 2, GETUTCDATE(), GETUTCDATE()),
    (11, 1, GETUTCDATE(), GETUTCDATE()),
    (12, 2, GETUTCDATE(), GETUTCDATE()),
    (13, 3, GETUTCDATE(), GETUTCDATE()),
    (14, 2, GETUTCDATE(), GETUTCDATE()),
    (15, 2, GETUTCDATE(), GETUTCDATE());


-- ================================================================================ --
-- ======================User Profile ========================================== --
-- ================================================================================ --

-- Inserting UserProfiles for existing users
INSERT INTO UserProfiles(LastName, Headline, Bio, OtherLink, LinkedInLink, PhoneNumber, DateOfBirth, UserId)
VALUES
('Doe', 'Software Engineer', 'Experienced software engineer with expertise in .NET and cloud technologies.', '', '', '1234567890', '1990-05-12', 1),
 
('Smith', 'Web Developer', 'Front-end developer with a passion for UI/UX design and React.', '', '', '9876543210', '1992-03-18', 2),
 
('Johnson', 'Full Stack Developer', 'Skilled in backend and frontend technologies with 5+ years of experience.', '', '', '1122334455', '1995-07-25', 3),
 
('Brown', 'Data Analyst', 'Data-driven professional with skills in SQL, Python, and visualization tools.', '', '', '6677889900', '1989-11-30', 4),
 
('Williams', 'Machine Learning Engineer', 'ML engineer focusing on deep learning and natural language processing.', '', '', '4455667788', '1994-09-09', 5);

-- Inserting addresses for user profiles
INSERT INTO UserProfileAddrs(City, State, Country, ZipCode, Address, UserProfileId)
VALUES
('New York', 'NY', 'USA', '10001', '123 Main St', 1),
 
('San Francisco', 'CA', 'USA', '94105', '456 Market St', 2),
 
('Chicago', 'IL', 'USA', '60601', '789 Lake Shore Dr', 3),
 
('Austin', 'TX', 'USA', '73301', '321 Tech Blvd', 4),
 
('Seattle', 'WA', 'USA', '98101', '654 Rainy Ave', 5);


-- Inserting profile images for user profiles
INSERT INTO UserProfileImgs(UserProfileImgURL, UserProfileId)
VALUES
('https://example.com/images/user1.jpg', 1),
('https://example.com/images/user2.jpg', 2),
('https://example.com/images/user3.jpg', 3),
('https://example.com/images/user4.jpg', 4),
('https://example.com/images/user5.jpg', 5);


-- ================================================================================ --
-- ======================Courses ========================================== --
-- ================================================================================ --


INSERT INTO Courses
(Title, Headline, Description, Duration, Fees, Level, ThumbnailUrl, Status, CreatedAt, UpdatedAt, Years, Months, Days, LanguageId, CourseCategoryId,UserId)
VALUES
('C# for Beginners', 'Start coding in C# today', 'Learn C# basics from scratch.', '10 hours', 49.99, 0, 'thumb1.jpg', 2, GETDATE(), GETDATE(), 0, 6, 0, 1, 1, 2),
 
('Mastering ASP.NET Core', 'Build modern web apps', 'Deep dive into ASP.NET Core and APIs.', '20 hours', 99.99, 1, 'thumb2.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 1, 1, 2),
 
('Intro to Python', 'Python from zero to hero', 'Perfect course for Python beginners.', '8 hours', 39.99, 0, 'thumb3.jpg', 2, GETDATE(), GETDATE(), 0, 4, 0, 2, 2, 2),
 
('React Essentials', 'Frontend with React', 'Understand React fundamentals.', '15 hours', 59.99, 1, 'thumb4.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 1, 3, 2),
 
('Data Structures in Java', 'Crack coding interviews', 'Focus on core DS concepts.', '12 hours', 69.99, 2, 'thumb5.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 2, 4, 2),
 
('Machine Learning Basics', 'Get started with ML', 'Intro to supervised learning.', '18 hours', 89.99, 1, 'thumb6.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 1, 5, 5),
 
('SQL for Everyone', 'Query with confidence', 'Learn SQL from basic to advanced.', '9 hours', 29.99, 0, 'thumb7.jpg', 2, GETDATE(), GETDATE(), 0, 6, 0, 3, 6, 2),
 
('Node.js Crash Course', 'Backend with JS', 'Build backend services using Node.', '11 hours', 54.99, 1, 'thumb8.jpg', 2, GETDATE(), GETDATE(), 0, 8, 0, 1, 3, 5),
 
('Kotlin for Android Devs', 'Create Android apps', 'Modern Android development with Kotlin.', '14 hours', 74.99, 2, 'thumb9.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 2, 7, 5),
 
('Docker Deep Dive', 'Deploy with containers', 'Hands-on with Docker.', '7 hours', 45.99, 1, 'thumb10.jpg', 2, GETDATE(), GETDATE(), 0, 9, 0, 1, 8, 2),
 
('Cyber Security 101', 'Stay safe online', 'Basics of ethical hacking.', '6 hours', 49.99, 0, 'thumb11.jpg', 2, GETDATE(), GETDATE(), 0, 5, 0, 3, 9, 5),
 
('GraphQL with Apollo', 'Efficient APIs', 'Learn to build flexible APIs.', '10 hours', 69.99, 2, 'thumb12.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 1, 3, 5),
 
('iOS App Development', 'Swift your way in', 'Intro to iOS with Swift.', '13 hours', 79.99, 2, 'thumb13.jpg', 2, GETDATE(), GETDATE(), 0, 11, 0, 2, 10, 2),
 
('Cloud Computing on AWS', 'Master the cloud', 'Basics of AWS cloud platform.', '17 hours', 99.99, 1, 'thumb14.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 1, 11, 5),
 
('Data Science with Python', 'Analyze like a pro', 'Python for data analysis.', '20 hours', 119.99, 2, 'thumb15.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 2, 5, 5);


INSERT INTO Courses (Title, Headline, Description, Duration, Fees, Level, ThumbnailUrl, Status, CreatedAt, UpdatedAt, Years, Months, Days, LanguageId, CourseCategoryId, UserId)
VALUES
('Java Programming Basics', 'Learn the fundamentals of Java', 'This course covers the basics of Java programming, including syntax, data types, and control structures.', 10, 49.99, 0, 'url1', 1, GETDATE(), GETDATE(), 0, 1, 0, 1, 1, 2),
('Advanced Java Techniques', 'Master advanced Java concepts', 'Dive deep into advanced Java programming techniques, including multithreading, concurrency, and design patterns.', 15, 99.99, 3, 'url2', 2, GETDATE(), GETDATE(), 0, 2, 0, 1, 1, 2),
('C# for Beginners', 'Start your journey with C#', 'An introductory course to C# programming, covering basic concepts and syntax.', 8, 39.99, 0, 'url3', 0, GETDATE(), GETDATE(), 0, 3, 0, 2, 2, 2),
('C# Advanced Topics', 'Enhance your C# skills', 'Explore advanced topics in C# programming, including LINQ, async programming, and more.', 12, 79.99, 3, 'url4', 3, GETDATE(), GETDATE(), 0, 4, 0, 2, 2, 2),
('Introduction to Programming', 'Learn the basics of programming', 'A beginner-friendly course that introduces the fundamental concepts of programming.', 6, 29.99, 0, 'url5', 1, GETDATE(), GETDATE(), 0, 5, 0, 3, 3, 2),
('JavaScript Essentials', 'Master JavaScript basics', 'Learn the essential concepts of JavaScript programming, including variables, functions, and events.', 7, 34.99, 0, 'url6', 2, GETDATE(), GETDATE(), 0, 6, 0, 1,4, 2),
('Python for Data Science', 'Data science with Python', 'An in-depth course on using Python for data science, covering libraries like Pandas, NumPy, and Matplotlib.', 20, 119.99, 2, 'url7', 3, GETDATE(), GETDATE(), 0, 7, 0,1, 5, 2),
('Web Development with JavaScript', 'Build dynamic websites', 'Learn how to create dynamic and interactive websites using JavaScript.', 14, 89.99, 2, 'url8', 4, GETDATE(), GETDATE(), 0, 8, 0, 1, 4, 8),
('Java for Web Development', 'Web development with Java', 'A comprehensive course on using Java for web development, including servlets, JSP, and Spring framework.', 18, 109.99, 2, 'url9', 1, GETDATE(), GETDATE(), 0, 9, 0, 1, 1, 11),
('C# for Web Applications', 'Build web apps with C#', 'Learn how to develop web applications using C# and ASP.NET.', 16, 99.99, 2, 'url10', 2, GETDATE(), GETDATE(), 0, 10, 0, 2, 2, 11),
('Java Programming for Beginners', 'Start coding with Java', 'An introductory course to Java programming, perfect for beginners.', 9, 44.99, 0, 'url11', 3, GETDATE(), GETDATE(), 0, 11, 0, 1, 1, 14),
('C# Programming Fundamentals', 'Learn C# basics', 'A beginner-friendly course on the fundamentals of C# programming.', 8, 39.99, 0, 'url12', 4, GETDATE(), GETDATE(), 0, 12, 0, 2, 2, 2),
('Java Programming Masterclass', 'Become a Java expert', 'A comprehensive masterclass on Java programming, covering advanced topics and best practices.', 20, 119.99, 3, 'url13', 1, GETDATE(), GETDATE(), 0, 1, 15, 1, 1, 15),
('C# Programming Masterclass', 'Master C# programming', 'An advanced course on C# programming, covering complex topics and real-world applications.', 18, 109.99, 3, 'url14', 2, GETDATE(), GETDATE(), 0, 2, 15, 2, 2, 15),
('Java Programming for Web Developers', 'Web development with Java', 'Learn how to use Java for web development, including frameworks and tools.', 15, 99.99, 2, 'url15', 3, GETDATE(), GETDATE(), 0, 3, 15, 1, 1, 15),
('C# Programming for Web Developers', 'Build web apps with C#', 'A course on developing web applications using C# and ASP.NET.', 14, 89.99, 2, 'url16', 4, GETDATE(), GETDATE(), 0, 4, 15, 2, 2, 15),
('Introduction to JavaScript', 'Learn JavaScript basics', 'A beginner-friendly course on JavaScript programming.', 6, 29.99, 0, 'url17', 1, GETDATE(), GETDATE(), 0, 5, 15, 1, 4, 15),
('Python Programming for Beginners', 'Start coding with Python', 'An introductory course to Python programming, perfect for beginners.', 8, 39.99, 0, 'url18', 2, GETDATE(), GETDATE(), 0, 6, 15, 2, 5, 15),
('Advanced Python Programming', 'Master Python programming', 'An advanced course on Python programming, covering complex topics and real-world applications.', 16, 99.99, 3, 'url19', 3, GETDATE(), GETDATE(), 0, 7, 15, 1, 5, 11),
('Web Development with Python', 'Build web apps with Python', 'Learn how to develop web applications using Python and Django.', 14, 89.99, 2, 'url20', 4, GETDATE(), GETDATE(), 0, 8, 15, 2, 5, 11),
('Data Structures and Algorithms in Java', 'Master data structures and algorithms', 'Learn how to implement data structures and algorithms in Java.', 12, 79.99, 3, 'url21', 1, GETDATE(), GETDATE(), 0, 9, 15, 1, 1, 11),
('C# Data Structures and Algorithms', 'Learn data structures and algorithms in C#', 'A comprehensive course on data structures and algorithms using C#.', 10, 69.99, 3, 'url22', 2, GETDATE(), GETDATE(), 0, 10, 15, 2, 2, 11),
('Java Programming for Mobile Apps', 'Develop mobile apps with Java', 'Learn how to create mobile applications using Java and Android.', 14, 89.99, 2, 'url23', 3, GETDATE(), GETDATE(), 0, 11, 15, 1, 1, 11),
('C# Programming for Mobile Apps', 'Build mobile apps with C#', 'A course on developing mobile applications using C# and Xamarin.', 12, 79.99, 2, 'url24', 4, GETDATE(), GETDATE(), 0, 12, 15, 2, 2, 11),
('Java Programming for Game Development', 'Game development with Java', 'Learn how to develop games using Java and popular game development frameworks.', 16, 99.99, 2, 'url25', 1, GETDATE(), GETDATE(), 0, 13, 15, 1, 1, 13),
('C# Programming for Game Development', 'Build games with C#', 'A course on developing games using C# and Unity.', 18, 109.99, 3, 'url26', 2, GETDATE(), GETDATE(), 0, 14, 15, 2, 2, 13),
('Java Programming for Cloud Computing', 'Cloud computing with Java', 'Learn how to use Java for cloud computing and deploy applications to the cloud.', 20, 119.99, 3, 'url27', 3, GETDATE(), GETDATE(), 0, 15, 15, 1, 1, 13);


-- ================================================================================ --
-- ======================Enrollements ========================================== --
-- ================================================================================ --

-- Status=>Enrolled, completed, cancelled,expired, failed
INSERT INTO Enrollments
	(EnrollmentOn, Status, ProgressPercentage, PurchasePrice, IsExpired, PurchaseAt, Years, Months, Days, UserId, CourseId)
	VALUES

	(GETDATE(), 2, 75, 39.99, 1, GETDATE(), 0, 2, 0, 1, 11),
	(GETDATE(), 0, 50, 59.99, 0, GETDATE(), 0, 3, 10, 2, 12),
	(GETDATE(), 3, 100, 69.99, 1, GETDATE(), 1, 0, 0, 4, 13),
	(GETDATE(), 4, 0, 24.99, 1, GETDATE(), 0, 0, 10, 5, 14),
	(GETDATE(), 0, 5, 99.99, 0, GETDATE(), 0, 6, 0, 3, 15),
	(GETDATE(), 1, 95, 34.99, 0, GETDATE(), 0, 3, 5, 2, 16),

	(GETDATE(), 0, 60, 44.99, 0, GETDATE(), 0, 3, 0, 1, 17),
	(GETDATE(), 2, 80, 59.99, 1, GETDATE(), 0, 4, 0, 2, 18),
	(GETDATE(), 3, 100, 89.99, 1, GETDATE(), 1, 0, 0, 5, 19),
	(GETDATE(), 0, 30, 19.99, 0, GETDATE(), 0, 1, 20, 4, 20),
	(GETDATE(), 1, 90, 39.99, 0, GETDATE(), 0, 2, 0, 3, 21),
	(GETDATE(), 0, 20, 24.99, 0, GETDATE(), 0, 3, 0, 1, 22),
	(GETDATE(), 0, 70, 49.99, 0, GETDATE(), 0, 2, 10, 2, 23),
	(GETDATE(), 0, 15, 44.99, 0, GETDATE(), 0, 1, 0, 5, 24),
	(GETDATE(), 2, 100, 74.99, 1, GETDATE(), 0, 4, 15, 3, 25),
	(GETDATE(), 0, 35, 54.99, 0, GETDATE(), 0, 2, 0, 2, 26),
	(GETDATE(), 1, 98, 64.99, 0, GETDATE(), 0, 6, 0, 4, 27);


INSERT INTO Ratings(Stars, Comment, RatedOn, IsUpdated, EnrollmentId)
VALUES
( 4, 'Really enjoyed the course.', GETUTCDATE(), 0, 11),
( 5, 'Outstanding delivery!', GETUTCDATE(), 0, 12),
( 2, 'Needs subtitles.', GETUTCDATE(), 0, 13),
( 3, 'Nice pace and coverage.', GETUTCDATE(), 0, 14),
( 4.2, 'Solid fundamentals covered.', GETUTCDATE(), 0, 15),
( 5, 'Excellent course!', GETUTCDATE(), 0, 16),
( 4, 'Very good and informative.', GETUTCDATE(), 0, 17),
( 3.5, 'Good but needs improvement.', GETUTCDATE(), 0, 18),
( 5, 'Loved the instructor’s approach.', GETUTCDATE(), 0, 19),
( 2, 'Too basic for advanced learners.', GETUTCDATE(), 0, 20),
( 4.5, 'Great content and structure.', GETUTCDATE(), 0, 21),
( 3, 'Decent course but outdated content.', GETUTCDATE(), 1, 22),
( 1, 'Not what I expected.', GETUTCDATE(), 0, 23),
( 4, 'Learned a lot!', GETUTCDATE(), 0, 24),
( 3, 'Okay-ish course.', GETUTCDATE(), 0, 25),
( 5, 'Perfect for beginners.', GETUTCDATE(), 0, 26),
( 2.5, 'Needs better explanations.', GETUTCDATE(), 1, 27),
( 4.5, 'Excellent examples!', GETUTCDATE(), 0, 28),
( 3.5, 'Average, but helpful.', GETUTCDATE(), 0, 29);

select * from Users;
select * from Roles
select * from UserRoles

select * from UserProfiles
select * from UserProfileImgs
select * from UserProfileAddrs


select * from Courses
select * from CourseCategories
select * from Languages

select * from Ratings
select * from Enrollments
use MiniUdemyDB;


select * from courses order by Title DESC; -- ASC default 
select * from courses order by CreatedAt DESC;