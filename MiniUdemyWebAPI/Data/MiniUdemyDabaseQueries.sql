-- Create database MiniUdemyDB;
-- Drop database MiniUdemyDB;
	use MiniUdemyDB
-- ================================================================================ --
-- =============================USER========================================= --
-- ================================================================================ --


-- Insert dummy users
INSERT INTO Users (FirstName, Email, Password, CreatedAt, UpdatedAt, IsActive, IsDeleted)
VALUES
('John', 'john@example.com', 'Pass@123', GETUTCDATE(), GETUTCDATE(), 1, 0),
 
('Jane', 'jane@example.com', 'Jane@1234', GETUTCDATE(), GETUTCDATE(), 1, 0),
 
('Alice', 'alice@example.com', 'Alice@5678', GETUTCDATE(), GETUTCDATE(), 1, 0),
 
('Bob', 'bob@example.com', 'Bob@321', GETUTCDATE(), GETUTCDATE(), 1, 0),
 
('Charlie', 'charlie@example.com', 'Char@789', GETUTCDATE(), GETUTCDATE(), 1, 0);

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


INSERT INTO Courses(
    Title, Description, Duration, Fees, Level, ThumbnailUrl, Status,
    CreatedAt, UpdatedAt, Years, Months, Days, LanguageId, CourseCategoryId,UserId
)
VALUES
('Java for Beginners', 'Comprehensive Java course for beginners.', '20 hours', 49.99, 0, 'https://example.com/img/java.jpg', 2, GETDATE(), GETDATE(), 0, 6, 0, 1, 1,2),
 
('Advanced Python', 'In-depth Python programming course.', '25 hours', 59.99, 2, 'https://example.com/img/python.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 2, 2,2),
 
('Data Structures in C++', 'Master DSA using C++.', '30 hours', 39.99, 1, 'https://example.com/img/dsa_cpp.jpg', 2, GETDATE(), GETDATE(), 0, 12, 0, 1, 3,2),
 
('Web Development with React', 'Frontend development using React.js.', '40 hours', 79.99, 1, 'https://example.com/img/react.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 3, 4,2),
 
('Machine Learning Basics', 'Start your ML journey here.', '50 hours', 99.99, 0, 'https://example.com/img/ml.jpg', 2, GETDATE(), GETDATE(), 0, 9, 0, 2, 5,2),
 
('Full Stack with MERN', 'Learn Mongo, Express, React, Node.', '60 hours', 109.99, 2, 'https://example.com/img/mern.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 3, 4,4),
 
('Kotlin for Android', 'Build Android apps using Kotlin.', '25 hours', 45.99, 1, 'https://example.com/img/kotlin.jpg', 2, GETDATE(), GETDATE(), 0, 6, 0, 1, 6,5),
 
('Flutter & Dart', 'Cross-platform mobile dev course.', '30 hours', 49.99, 0, 'https://example.com/img/flutter.jpg', 2, GETDATE(), GETDATE(), 0, 9, 0, 1, 6,5),
 
('Cybersecurity Essentials', 'Learn core cybersecurity skills.', '35 hours', 69.99, 1, 'https://example.com/img/cyber.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 2, 7,5),
 
('Cloud with AWS', 'Get started with AWS cloud.', '45 hours', 89.99, 2, 'https://example.com/img/aws.jpg', 2, GETDATE(), GETDATE(), 0, 6, 0, 3, 8,5),
 
('SQL Mastery', 'Master SQL for data management.', '20 hours', 29.99, 0, 'https://example.com/img/sql.jpg', 2, GETDATE(), GETDATE(), 0, 12, 0, 2, 9,5),
 
('Ethical Hacking', 'Learn the art of ethical hacking.', '40 hours', 74.99, 2, 'https://example.com/img/hacking.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 1, 7,2),
 
('Docker & Kubernetes', 'Containers & orchestration in devops.', '35 hours', 84.99, 1, 'https://example.com/img/docker.jpg', 2, GETDATE(), GETDATE(), 0, 9, 0, 1, 10,2),
 
('AI with TensorFlow', 'Build AI models using TensorFlow.', '55 hours', 99.99, 2, 'https://example.com/img/tensorflow.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 2, 5,5),
 
('C Programming Basics', 'Beginner-friendly C programming course.', '15 hours', 19.99, 0, 'https://example.com/img/c.jpg', 2, GETDATE(), GETDATE(), 0, 6, 0, 1, 1,2),
 
('Spring Boot Crash Course', 'Backend dev using Spring Boot.', '25 hours', 59.99, 1, 'https://example.com/img/spring.jpg', 2, GETDATE(), GETDATE(), 0, 12, 0, 1, 4,5),
 
('JavaScript Essentials', 'Core JavaScript concepts.', '20 hours', 39.99, 0, 'https://example.com/img/js.jpg', 2, GETDATE(), GETDATE(), 0, 6, 0, 3, 4,2),
 
('Node.js & Express', 'Backend using Node and Express.', '30 hours', 64.99, 1, 'https://example.com/img/node.jpg', 2, GETDATE(), GETDATE(), 0, 9, 0, 3, 4,2),
 
('Intro to DevOps', 'CI/CD pipelines & automation.', '35 hours', 79.99, 1, 'https://example.com/img/devops.jpg', 2, GETDATE(), GETDATE(), 1, 0, 0, 1, 10,2),
 
('Agile & Scrum', 'Agile methodology for dev teams.', '10 hours', 24.99, 0, 'https://example.com/img/agile.jpg', 2, GETDATE(), GETDATE(), 0, 3, 0, 1, 9,2);




-- ================================================================================ --
-- ======================Enrollements ========================================== --
-- ================================================================================ --

-- Status=>Enrolled, completed, cancelled,expired, failed
INSERT INTO Enrollments
	(EnrollmentOn, Status, ProgressPercentage, PurchasePrice, IsExpired, PurchaseAt, Years, Months, Days, UserId, CourseId)
	VALUES
	(GETDATE(), 0, 10, 49.99, 0, GETDATE(), 0, 3, 0, 1, 8),
	(GETDATE(), 1, 100, 29.99, 0, GETDATE(), 0, 6, 0, 2, 9),
	(GETDATE(), 0, 25, 19.99, 0, GETDATE(), 0, 1, 15, 3, 10),
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
( 4, 'Really enjoyed the course.', GETUTCDATE(), 0, 3),
( 5, 'Outstanding delivery!', GETUTCDATE(), 0, 4),
( 2, 'Needs subtitles.', GETUTCDATE(), 0, 5),
( 3, 'Nice pace and coverage.', GETUTCDATE(), 0, 6),
( 4.2, 'Solid fundamentals covered.', GETUTCDATE(), 0, 7),
( 5, 'Excellent course!', GETUTCDATE(), 0, 8),
( 4, 'Very good and informative.', GETUTCDATE(), 0, 9),
( 3.5, 'Good but needs improvement.', GETUTCDATE(), 0, 10),
( 5, 'Loved the instructor’s approach.', GETUTCDATE(), 0, 11),
( 2, 'Too basic for advanced learners.', GETUTCDATE(), 0, 12),
( 4.5, 'Great content and structure.', GETUTCDATE(), 0, 13),
( 3, 'Decent course but outdated content.', GETUTCDATE(), 1, 14),
( 1, 'Not what I expected.', GETUTCDATE(), 0, 15),
( 4, 'Learned a lot!', GETUTCDATE(), 0, 16),
( 3, 'Okay-ish course.', GETUTCDATE(), 0, 17),
( 5, 'Perfect for beginners.', GETUTCDATE(), 0, 18),
( 2.5, 'Needs better explanations.', GETUTCDATE(), 1, 19),
( 4.5, 'Excellent examples!', GETUTCDATE(), 0, 20),
( 3.5, 'Average, but helpful.', GETUTCDATE(), 0, 21);

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

