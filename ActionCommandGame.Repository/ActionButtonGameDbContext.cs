using ActionCommandGame.Model;
using ActionCommandGame.Repository.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ActionCommandGame.Repository
{
    public class ActionButtonGameDbContext: DbContext
    {
        public ActionButtonGameDbContext(DbContextOptions<ActionButtonGameDbContext> options): base(options)
        {
            
        }

        public DbSet<PositiveGameEvent> PositiveGameEvents { get; set; }
        public DbSet<NegativeGameEvent> NegativeGameEvents { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerItem> PlayerItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureRelationships();

            base.OnModelCreating(modelBuilder);
        }

        public void Initialize()
        {
            GeneratePositiveGameEvents();
            GenerateNegativeGameEvents();
            GenerateExploitEfficiencyItems();
            GenerateSecurityItems();
            GenerateFoodItems();
            GenerateDecorativeItems();

            

            Players.Add(new Player { Name = "John Doe", Money = 100 });

            SaveChanges();
        }

        private void GeneratePositiveGameEvents()
        {
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Vulnerability Exploit Successful", Description = "You successfully exploit a vulnerability in the system, gaining access to valuable data.", Money = 50, Experience = 30, Probability = 2500, SecurityLoss = 1 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Encryption Bypassed", Description = "You bypass the encryption on a secure database, revealing sensitive information.", Money = 60, Experience = 40, Probability = 2475, SecurityLoss = 1 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Backdoor Installed", Description = "You install a backdoor into the system, allowing you to access it remotely in the future.", Money = 70, Experience = 50, Probability = 2450, SecurityLoss = 1 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Firewall Breached", Description = "You breach the firewall protecting a corporate network, gaining unrestricted access.", Money = 80, Experience = 60, Probability = 2425, SecurityLoss = 1 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Zero-Day Exploit Discovered", Description = "You discover a zero-day exploit in the system, giving you unparalleled access.", Money = 90, Experience = 70, Probability = 2400, SecurityLoss = 2 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Admin Credentials Acquired", Description = "You obtain admin credentials, granting you administrative privileges.", Money = 100, Experience = 80, Probability = 2375, SecurityLoss = 2 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Database Dump Successful", Description = "You successfully dump the entire contents of a database, containing valuable data.", Money = 110, Experience = 90, Probability = 2350, SecurityLoss = 3 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Phishing Attack Successful", Description = "You execute a successful phishing attack, obtaining login credentials from unsuspecting users.", Money = 120, Experience = 100, Probability = 2325, SecurityLoss = 3 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Malware Payload Deployed", Description = "You deploy a malware payload onto the system, allowing you to monitor and control it remotely.", Money = 130, Experience = 110, Probability = 2300, SecurityLoss = 4 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Network Traffic Intercepted", Description = "You intercept sensitive network traffic, capturing valuable information.", Money = 140, Experience = 120, Probability = 2275, SecurityLoss = 4 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Social Engineering Success", Description = "You successfully use social engineering techniques to trick an employee into providing access to secure areas.", Money = 150, Experience = 130, Probability = 2250, SecurityLoss = 5 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Exploit Chain Completed", Description = "You chain together multiple exploits to gain access to highly secure systems.", Money = 160, Experience = 140, Probability = 2225, SecurityLoss = 5 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Remote Code Execution Achieved", Description = "You achieve remote code execution on a critical server, giving you full control.", Money = 170, Experience = 150, Probability = 2200, SecurityLoss = 6 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Data Exfiltration Successful", Description = "You successfully exfiltrate sensitive data from the target system without detection.", Money = 180, Experience = 160, Probability = 2175, SecurityLoss = 6 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "IoT Device Compromised", Description = "You compromise an Internet of Things (IoT) device, gaining access to its network.", Money = 190, Experience = 170, Probability = 2150, SecurityLoss = 7 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Exploit Kit Utilized", Description = "You utilize an exploit kit to automate the exploitation of multiple vulnerabilities.", Money = 200, Experience = 180, Probability = 2125, SecurityLoss = 7 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Privilege Escalation Succeeded", Description = "You successfully escalate your privileges, gaining access to restricted resources.", Money = 210, Experience = 190, Probability = 2100, SecurityLoss = 8 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Intrusion Detection Evasion", Description = "You evade detection by the system's intrusion detection mechanisms, remaining undetected.", Money = 220, Experience = 200, Probability = 2075, SecurityLoss = 8 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Biometric System Bypassed", Description = "You bypass a biometric security system, gaining unauthorized access to a secure facility.", Money = 230, Experience = 210, Probability = 2050, SecurityLoss = 9 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Blockchain Transaction Manipulated", Description = "You manipulate a blockchain transaction, altering the ledger to your advantage.", Money = 240, Experience = 220, Probability = 2025, SecurityLoss = 9 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Firmware Tampering Successful", Description = "You successfully tamper with the firmware of a device, gaining control over its functionality.", Money = 250, Experience = 230, Probability = 2000, SecurityLoss = 10 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Shadow IT System Access Gained", Description = "You gain access to a shadow IT system, which was previously unknown to the organization.", Money = 260, Experience = 240, Probability = 1975, SecurityLoss = 10 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Side Channel Attack Executed", Description = "You execute a side channel attack, extracting sensitive information through unconventional means.", Money = 270, Experience = 250, Probability = 1950, SecurityLoss = 11 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Supply Chain Compromise", Description = "You compromise the supply chain, inserting malicious components into products or software updates.", Money = 280, Experience = 260, Probability = 1925, SecurityLoss = 11 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Rogue Access Point Deployed", Description = "You deploy a rogue access point, intercepting network traffic from unsuspecting users.", Money = 290, Experience = 270, Probability = 1900, SecurityLoss = 12 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Denial-of-Service Attack Successful", Description = "You successfully launch a denial-of-service attack, disrupting services and causing chaos.", Money = 300, Experience = 280, Probability = 1875, SecurityLoss = 12 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Supply Chain Attack Successful", Description = "You successfully execute a supply chain attack, compromising multiple organizations.", Money = 310, Experience = 290, Probability = 1850, SecurityLoss = 13 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Keylogger Installed", Description = "You install a keylogger on the target system, capturing keystrokes and login credentials.", Money = 320, Experience = 300, Probability = 1825, SecurityLoss = 13 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Man-in-the-Middle Attack Successful", Description = "You successfully execute a man-in-the-middle attack, intercepting and modifying communication between parties.", Money = 330, Experience = 310, Probability = 1800, SecurityLoss = 14 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Cryptojacking Operation Established", Description = "You establish a cryptojacking operation, using the target system's resources to mine cryptocurrency.", Money = 340, Experience = 320, Probability = 1775, SecurityLoss = 14 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Insider Threat Exploited", Description = "You exploit an insider threat, leveraging the access of a trusted individual.", Money = 350, Experience = 330, Probability = 1750, SecurityLoss = 15 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Smart Contract Exploited", Description = "You exploit a vulnerability in a smart contract, siphoning funds from the blockchain.", Money = 360, Experience = 340, Probability = 1725, SecurityLoss = 15 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Compromised Credential Sale", Description = "You successfully sell compromised credentials on the dark web, turning a profit.", Money = 370, Experience = 350, Probability = 1700, SecurityLoss = 16 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "DNS Spoofing Attack Successful", Description = "You successfully execute a DNS spoofing attack, redirecting users to malicious websites.", Money = 380, Experience = 360, Probability = 1675, SecurityLoss = 16 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Ransomware Infection Deployed", Description = "You deploy a ransomware infection on the target system, encrypting valuable data and demanding payment for decryption.", Money = 390, Experience = 370, Probability = 1650, SecurityLoss = 17 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Zero-Click Exploit Utilized", Description = "You utilize a zero-click exploit to compromise a device without any user interaction.", Money = 400, Experience = 380, Probability = 1625, SecurityLoss = 17 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Reverse Engineering Success", Description = "You successfully reverse engineer a proprietary software, uncovering vulnerabilities and weaknesses.", Money = 410, Experience = 390, Probability = 1600, SecurityLoss = 18 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Memory Corruption Attack", Description = "You execute a memory corruption attack, exploiting vulnerabilities in the system's memory management.", Money = 420, Experience = 400, Probability = 1575, SecurityLoss = 18 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Mobile Device Compromised", Description = "You compromise a mobile device, gaining access to personal information and sensitive data.", Money = 430, Experience = 410, Probability = 1550, SecurityLoss = 19 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Distributed Denial-of-Service Attack", Description = "You launch a distributed denial-of-service attack, overwhelming the target's servers with traffic.", Money = 440, Experience = 420, Probability = 1525, SecurityLoss = 19 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Physical Security Bypassed", Description = "You bypass physical security measures, gaining unauthorized access to a secure facility.", Money = 450, Experience = 430, Probability = 1500, SecurityLoss = 20 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Voice Phishing Successful", Description = "You successfully execute a voice phishing (vishing) attack, tricking individuals into revealing sensitive information over the phone.", Money = 460, Experience = 440, Probability = 1475, SecurityLoss = 20 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Rootkit Installation", Description = "You successfully install a rootkit on the target system, allowing you to maintain persistent access.", Money = 470, Experience = 450, Probability = 1450, SecurityLoss = 21 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Traffic Analysis Evasion", Description = "You evade traffic analysis techniques, ensuring that your activities remain undetected.", Money = 480, Experience = 460, Probability = 1425, SecurityLoss = 21 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Watering Hole Attack", Description = "You execute a watering hole attack, infecting websites frequented by your targets with malware.", Money = 490, Experience = 470, Probability = 1400, SecurityLoss = 22 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Supply Chain Hijacking", Description = "You hijack the supply chain, inserting malicious code into legitimate software updates.", Money = 500, Experience = 480, Probability = 1375, SecurityLoss = 22 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Eavesdropping Success", Description = "You successfully eavesdrop on sensitive communications, gathering valuable intelligence.", Money = 510, Experience = 490, Probability = 1350, SecurityLoss = 23 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Firmware Backdoor Installed", Description = "You install a backdoor into the firmware of a device, providing persistent access.", Money = 520, Experience = 500, Probability = 1325, SecurityLoss = 23 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Physical Device Tampering", Description = "You tamper with physical devices, compromising their integrity and functionality.", Money = 530, Experience = 510, Probability = 1300, SecurityLoss = 24 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Exploit as a Service", Description = "You purchase an exploit as a service, leveraging the skills of others to achieve your goals.", Money = 540, Experience = 520, Probability = 1275, SecurityLoss = 24 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Sim Card Swap Success", Description = "You successfully swap a SIM card, gaining access to a target's phone number and communications.", Money = 550, Experience = 530, Probability = 1250, SecurityLoss = 25 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "WPA2 Key Cracked", Description = "You crack the WPA2 key of a wireless network, gaining access to its traffic.", Money = 560, Experience = 540, Probability = 1225, SecurityLoss = 25 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Password Spray Attack Success", Description = "You successfully execute a password spray attack, gaining access to multiple accounts.", Money = 570, Experience = 550, Probability = 1200, SecurityLoss = 26 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Rogue Software Installed", Description = "You install rogue software onto the target system, compromising its security and integrity.", Money = 580, Experience = 560, Probability = 1175, SecurityLoss = 26 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Insider Trading Information Obtained", Description = "You obtain insider trading information, allowing you to profit from stock market manipulation.", Money = 590, Experience = 570, Probability = 1150, SecurityLoss = 27 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Fingerprint Forgery Success", Description = "You successfully forge fingerprints, bypassing biometric authentication measures.", Money = 600, Experience = 580, Probability = 1125, SecurityLoss = 27 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Logic Bomb Deployed", Description = "You deploy a logic bomb onto the target system, triggering a malicious payload at a specified time.", Money = 610, Experience = 590, Probability = 1100, SecurityLoss = 28 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Exploit Development Success", Description = "You successfully develop and deploy a custom exploit, tailored to the target system.", Money = 620, Experience = 600, Probability = 1075, SecurityLoss = 28 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Cross-Site Scripting Attack", Description = "You execute a cross-site scripting (XSS) attack, injecting malicious scripts into web pages.", Money = 630, Experience = 610, Probability = 1050, SecurityLoss = 29 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Data Masking Bypassed", Description = "You bypass data masking techniques, revealing sensitive information hidden within.", Money = 640, Experience = 620, Probability = 1025, SecurityLoss = 29 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Pentesting Engagement Success", Description = "You successfully complete a penetration testing engagement, identifying and exploiting vulnerabilities in the target system.", Money = 650, Experience = 630, Probability = 1000, SecurityLoss = 30 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Logic Flaw Exploited", Description = "You exploit a logic flaw in the system, manipulating it to your advantage.", Money = 660, Experience = 640, Probability = 975, SecurityLoss = 30 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Custom Malware Developed", Description = "You develop custom malware tailored to the target system, maximizing its effectiveness.", Money = 670, Experience = 650, Probability = 950, SecurityLoss = 31 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Steganography Success", Description = "You successfully use steganography to hide information within digital media, evading detection.", Money = 680, Experience = 660, Probability = 925, SecurityLoss = 31 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "RFID Cloning Success", Description = "You successfully clone RFID credentials, gaining unauthorized access to secure areas.", Money = 690, Experience = 670, Probability = 900, SecurityLoss = 32 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Keystroke Dynamics Analysis", Description = "You analyze keystroke dynamics to identify individuals based on their typing patterns.", Money = 700, Experience = 680, Probability = 875, SecurityLoss = 32 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Script Kiddie Tools Utilized", Description = "You utilize script kiddie tools to automate hacking tasks, saving time and effort.", Money = 710, Experience = 690, Probability = 850, SecurityLoss = 33 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Network Protocol Exploited", Description = "You exploit a vulnerability in a network protocol, gaining unauthorized access to network resources.", Money = 720, Experience = 700, Probability = 825, SecurityLoss = 33 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Cryptanalysis Success", Description = "You successfully crack a cryptographic algorithm, decrypting encrypted data.", Money = 730, Experience = 710, Probability = 800, SecurityLoss = 34 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Voice Recognition Bypassed", Description = "You bypass voice recognition systems, gaining access to secure voice-controlled devices.", Money = 740, Experience = 720, Probability = 775, SecurityLoss = 34 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "SQL Injection Attack", Description = "You execute a SQL injection attack, exploiting vulnerabilities in the database management system.", Money = 750, Experience = 730, Probability = 750, SecurityLoss = 35 });

            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Government Database Infiltrated", Description = "You infiltrate a government database, gaining access to classified information.", Money = 1500, Experience = 1000, Probability = 250, SecurityLoss = 50 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Corporate Mainframe Breached", Description = "You breach the mainframe of a major corporation, extracting sensitive data.", Money = 2000, Experience = 150, Probability = 247, SecurityLoss = 55 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Military Server Compromised", Description = "You compromise a military server, gaining access to top-secret military intelligence.", Money = 2500, Experience = 2000, Probability = 245, SecurityLoss = 60 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Central Bank Network Penetrated", Description = "You penetrate the network of a central bank, gaining access to financial transactions.", Money = 3000, Experience = 2500, Probability = 242, SecurityLoss = 65 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Nuclear Facility Access Obtained", Description = "You obtain access to a nuclear facility's control systems, potentially causing catastrophic consequences.", Money = 3500, Experience = 3000, Probability = 240, SecurityLoss = 70 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Intelligence Agency System Compromised", Description = "You compromise the system of an intelligence agency, gaining access to surveillance data.", Money = 4000, Experience = 3500, Probability = 237, SecurityLoss = 75 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Fortune 500 Company Data Exfiltrated", Description = "You successfully exfiltrate sensitive data from a Fortune 500 company, potentially impacting global markets.", Money = 4500, Experience = 4000, Probability = 235, SecurityLoss = 80 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Space Agency Satellite Control Seized", Description = "You seize control of a space agency's satellite, potentially disrupting communications and navigation systems.", Money = 5000, Experience = 4500, Probability = 232, SecurityLoss = 85 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "International Organization Server Breached", Description = "You breach the server of an international organization, gaining access to diplomatic communications.", Money = 5500, Experience = 5000, Probability = 230, SecurityLoss = 90 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Healthcare Institution Data Stolen", Description = "You steal patient data from a major healthcare institution, potentially compromising personal and medical information.", Money = 6000, Experience = 5500, Probability = 227, SecurityLoss = 95 });

            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Energy Grid Control Compromised", Description = "You compromise the control system of an energy grid, potentially causing widespread power outages.", Money = 6500, Experience = 6000, Probability = 225, SecurityLoss = 100 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "International Airport Systems Breached", Description = "You breach the systems of an international airport, potentially disrupting air traffic control and security measures.", Money = 7000, Experience = 6500, Probability = 222, SecurityLoss = 105 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Global Payment Network Accessed", Description = "You gain access to a global payment network, potentially facilitating large-scale financial fraud.", Money = 7500, Experience = 7000, Probability = 220, SecurityLoss = 110 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Telecommunications Infrastructure Compromised", Description = "You compromise the telecommunications infrastructure of a country, potentially disrupting communication networks.", Money = 8000, Experience = 7500, Probability = 217, SecurityLoss = 115 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Aerospace Company Research Stolen", Description = "You steal research data from a leading aerospace company, potentially undermining national security.", Money = 8500, Experience = 8000, Probability = 215, SecurityLoss = 120 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Critical Infrastructure Control Seized", Description = "You seize control of critical infrastructure, potentially causing widespread disruption and chaos.", Money = 9000, Experience = 8500, Probability = 212, SecurityLoss = 125 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Global Banking System Compromised", Description = "You compromise the global banking system, potentially causing financial collapse.", Money = 9500, Experience = 9000, Probability = 210, SecurityLoss = 130 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Satellite Network Hijacked", Description = "You hijack a satellite network, potentially disrupting global communication and navigation systems.", Money = 10000, Experience = 9500, Probability = 207, SecurityLoss = 135 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Cybersecurity Firm Data Breached", Description = "You breach the systems of a cybersecurity firm, potentially obtaining advanced hacking tools and techniques.", Money = 10500, Experience = 10000, Probability = 205, SecurityLoss = 140 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "National Intelligence Service Infiltrated", Description = "You infiltrate the systems of a national intelligence service, potentially gaining access to classified intelligence.", Money = 1100, Experience = 10500, Probability = 202, SecurityLoss = 145 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Global Stock Exchange Manipulated", Description = "You manipulate a global stock exchange, potentially causing economic turmoil.", Money = 11500, Experience = 11000, Probability = 200, SecurityLoss = 150 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Centralized Control System Compromised", Description = "You compromise a centralized control system, potentially causing widespread infrastructure failures.", Money = 12000, Experience = 11500, Probability = 197, SecurityLoss = 155 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "International Intelligence Network Breached", Description = "You breach an international intelligence network, potentially exposing covert operations and agents.", Money = 12500, Experience = 12000, Probability = 195, SecurityLoss = 160 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Global Satellite Communication Intercepted", Description = "You intercept global satellite communications, potentially obtaining sensitive diplomatic and military information.", Money = 13000, Experience = 12500, Probability = 192, SecurityLoss = 165 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Intercontinental Ballistic Missile Control Seized", Description = "You seize control of an intercontinental ballistic missile, potentially triggering international conflict.", Money = 13500, Experience = 13000, Probability = 190, SecurityLoss = 170 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Global Air Traffic Control Compromised", Description = "You compromise global air traffic control systems, potentially causing mid-air collisions and chaos.", Money = 14000, Experience = 13500, Probability = 187, SecurityLoss = 175 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "International Banking Network Breached", Description = "You breach an international banking network, potentially facilitating large-scale financial theft.", Money = 14500, Experience = 14000, Probability = 185, SecurityLoss = 180 });

            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Global Cybersecurity Infrastructure Compromised", Description = "You compromise the global cybersecurity infrastructure, potentially leaving entire nations vulnerable to cyber attacks.", Money = 15000, Experience = 14500, Probability = 182, SecurityLoss = 185 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "International Space Station Control Seized", Description = "You seize control of the International Space Station, potentially endangering the lives of astronauts and disrupting space research.", Money = 15500, Experience = 15000, Probability = 180, SecurityLoss = 190 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Global Communications Network Compromised", Description = "You compromise the global communications network, potentially causing worldwide communication blackout.", Money = 16000, Experience = 15500, Probability = 177, SecurityLoss = 195 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "World Bank System Breached", Description = "You breach the systems of the World Bank, potentially causing economic collapse and global financial crisis.", Money = 16500, Experience = 16000, Probability = 175, SecurityLoss = 200 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Global Surveillance Network Infiltrated", Description = "You infiltrate the global surveillance network, potentially exposing government surveillance programs and compromising national security.", Money = 17000, Experience = 16500, Probability = 172, SecurityLoss = 205 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "International Nuclear Arsenal Control Seized", Description = "You seize control of the international nuclear arsenal, potentially triggering global nuclear war.", Money = 17500, Experience = 17000, Probability = 170, SecurityLoss = 210 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Global Financial Clearinghouse Compromised", Description = "You compromise the global financial clearinghouse, potentially disrupting global financial transactions and causing economic chaos.", Money = 18000, Experience = 17500, Probability = 167, SecurityLoss = 215 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Worldwide Internet Infrastructure Breached", Description = "You breach the worldwide internet infrastructure, potentially causing a global internet blackout and disrupting communication worldwide.", Money = 18500, Experience = 18000, Probability = 165, SecurityLoss = 220 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Global Satellite Navigation System Hacked", Description = "You hack into the global satellite navigation system, potentially causing widespread navigation errors and chaos in transportation.", Money = 19000, Experience = 18500, Probability = 162, SecurityLoss = 225 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "International Intelligence Alliance Infiltrated", Description = "You infiltrate an international intelligence alliance, potentially compromising intelligence-sharing agreements and alliances between nations.", Money = 19500, Experience = 19000, Probability = 160, SecurityLoss = 230 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Global Climate Control Network Compromised", Description = "You compromise the global climate control network, potentially causing catastrophic climate events and environmental disasters.", Money = 2000, Experience = 19500, Probability = 157, SecurityLoss = 235 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Global Quantum Communication Network Breached", Description = "You breach the global quantum communication network, potentially compromising quantum encryption and secure communication worldwide.", Money = 20500, Experience = 20000, Probability = 155, SecurityLoss = 240 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Interplanetary Colonization Control Seized", Description = "You seize control of interplanetary colonization efforts, potentially endangering the lives of colonists and disrupting humanity's expansion into space.", Money = 21000, Experience = 20500, Probability = 152, SecurityLoss = 245 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Universal Artificial Intelligence Network Breached", Description = "You breach the universal artificial intelligence network, potentially causing an AI uprising and global technological catastrophe.", Money = 21500, Experience = 21000, Probability = 150, SecurityLoss = 250 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Time Travel Infrastructure Compromised", Description = "You compromise the infrastructure for time travel, potentially causing paradoxes and altering the course of history.", Money = 22000, Experience = 21500, Probability = 147, SecurityLoss = 255 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Multiverse Control Center Seized", Description = "You seize control of the multiverse control center, potentially causing catastrophic disruptions to the fabric of reality.", Money = 22500, Experience = 22000, Probability = 145, SecurityLoss = 260 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Divine Realm Access Obtained", Description = "You obtain access to the divine realm, potentially reshaping the cosmos and altering the balance of power between gods and mortals.", Money = 23000, Experience = 22500, Probability = 142, SecurityLoss = 265 });

            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Reality Simulation Matrix Hacked", Description = "You hack into the reality simulation matrix, potentially gaining control over simulated worlds and altering the course of existence.", Money = 23500, Experience = 23000, Probability = 140, SecurityLoss = 270 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Existence Protocol Manipulated", Description = "You manipulate the existence protocol, potentially rewriting the fundamental laws of reality and reshaping existence itself.", Money = 24000, Experience = 23500, Probability = 137, SecurityLoss = 275 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Ultimate Power Attained", Description = "You attain ultimate power, becoming a godlike being capable of reshaping the universe according to your will.", Money = 24500, Experience = 24000, Probability = 135, SecurityLoss = 280 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Cosmic Balance Shattered", Description = "You shatter the cosmic balance, plunging the universe into chaos and uncertainty.", Money = 25000, Experience = 24500, Probability = 132, SecurityLoss = 285 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Reality Collapse Imminent", Description = "Your actions trigger a reality collapse, bringing an end to existence as we know it.", Money = 25500, Experience = 25000, Probability = 130, SecurityLoss = 290 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "End of Time", Description = "You bring about the end of time itself, ushering in a state of eternal nothingness.", Money = 26000, Experience = 25500, Probability = 127, SecurityLoss = 295 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Omega Point Reached", Description = "You reach the Omega Point, transcending reality and ascending to a higher plane of existence.", Money = 26500, Experience = 26000, Probability = 125, SecurityLoss = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Universe Reboot Initiated", Description = "You initiate a universe reboot, resetting the cosmos and starting anew.", Money = 27000, Experience = 26500, Probability = 122, SecurityLoss = 305 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Multiverse Collapse", Description = "Your actions trigger a collapse of the multiverse, erasing all possibilities and bringing about absolute nothingness.", Money = 27500, Experience = 27000, Probability = 120, SecurityLoss = 310 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Cosmic Reset", Description = "You initiate a cosmic reset, returning everything to its primordial state before the dawn of time.", Money = 28000, Experience = 27500, Probability = 117, SecurityLoss = 315 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Creation Reborn", Description = "You initiate the rebirth of creation, setting the stage for a new universe to emerge from the ashes of the old.", Money = 28500, Experience = 28000, Probability = 115, SecurityLoss = 320 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Eternal Recurrence", Description = "You trigger an eternal recurrence, ensuring that the universe will repeat its cycle for all eternity.", Money = 29000, Experience = 28500, Probability = 112, SecurityLoss = 325 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Metaverse Ascension", Description = "You ascend to the metaverse, transcending the limitations of reality and becoming one with the digital cosmos.", Money = 29500, Experience = 29000, Probability = 110, SecurityLoss = 330 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Universal Enlightenment", Description = "You bring about universal enlightenment, awakening every sentient being to their true nature and purpose.", Money = 30000, Experience = 29500, Probability = 107, SecurityLoss = 335 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Singularity Achieved", Description = "You achieve the technological singularity, merging with artificial intelligence and transcending human limitations.", Money = 30500, Experience = 30000, Probability = 105, SecurityLoss = 340 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Cosmic Harmony Attained", Description = "You attain cosmic harmony, bringing balance to the universe and ending all conflict and suffering.", Money = 31000, Experience = 30500, Probability = 102, SecurityLoss = 345 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Ultimate Reality", Description = "You reach the ultimate reality, where all possibilities converge and all truths are known.", Money = 31500, Experience = 31000, Probability = 100, SecurityLoss = 350 });


        }

        public void GenerateNegativeGameEvents()
        {
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Security Alert",
                Description = "Your hacking attempt triggers a security alert, and the system starts tracing your location.",
                SecurityWithGearDescription = "Your encryption tools help you evade detection, minimizing the risk.",
                SecurityWithoutGearDescription = "You panic and make a hasty retreat, leaving behind evidence of your intrusion.",
                SecurityLoss = 5,
                Probability = 70
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Firewall Breach",
                Description = "You encounter a firewall that blocks your progress and alerts the system administrator.",
                SecurityWithGearDescription = "Your hacking tools allow you to bypass the firewall, but not without leaving traces.",
                SecurityWithoutGearDescription = "You struggle to bypass the firewall but fail, attracting attention to your activities.",
                SecurityLoss = 8,
                Probability = 60
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Data Corruption",
                Description = "Your hacking attempt inadvertently corrupts critical data, causing system malfunctions.",
                SecurityWithGearDescription = "Your encryption software prevents widespread damage, limiting the impact.",
                SecurityWithoutGearDescription = "Your hacking tools malfunction, leading to widespread data corruption and system failure.",
                SecurityLoss = 14,
                Probability = 50
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Counter Hack",
                Description = "As you hack into the system, you encounter a skilled hacker who fights back, attempting to trace your identity.",
                SecurityWithGearDescription = "Your cybersecurity measures help you defend against the counterattack, but not without a struggle.",
                SecurityWithoutGearDescription = "You find yourself outmatched by the opposing hacker, forced to retreat with your tail between your legs.",
                SecurityLoss = 25,
                Probability = 40
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "System Lockout",
                Description = "The system detects your unauthorized access and locks you out, preventing further hacking attempts.",
                SecurityWithGearDescription = "Your hacking tools manage to bypass the lockout, but not before raising suspicions.",
                SecurityWithoutGearDescription = "You are completely locked out of the system, leaving you unable to proceed with your hacking.",
                SecurityLoss = 9,
                Probability = 50
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Network Shutdown",
                Description = "Your hacking attempt triggers a network shutdown, cutting off access to valuable resources.",
                SecurityWithGearDescription = "Your hacking tools allow you to restore network access, albeit with some difficulty.",
                SecurityWithoutGearDescription = "You inadvertently cause a network-wide shutdown, drawing attention to your actions.",
                SecurityLoss = 6,
                Probability = 60
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Trapdoor",
                Description = "You stumble upon a hidden trapdoor in the system, leading to a virtual maze of security measures.",
                SecurityWithGearDescription = "Your hacking tools help you navigate the trapdoor maze, but not without setbacks.",
                SecurityWithoutGearDescription = "You fall into the trapdoor maze and struggle to find your way out, wasting precious time and resources.",
                SecurityLoss = 17,
                Probability = 40
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Data Encryption",
                Description = "You encounter heavily encrypted data that proves difficult to crack, delaying your progress.",
                SecurityWithGearDescription = "Your decryption software helps you unravel the encryption, though it takes longer than expected.",
                SecurityWithoutGearDescription = "You struggle to decrypt the data and make little progress, frustrating your hacking efforts.",
                SecurityLoss = 8,
                Probability = 50
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Admin Detection",
                Description = "Your hacking attempt is detected by the system administrator, who launches a counteroffensive.",
                SecurityWithGearDescription = "Your cybersecurity measures help you evade detection, though not without close calls.",
                SecurityWithoutGearDescription = "You are detected by the system administrator and face aggressive countermeasures, forcing you to retreat.",
                SecurityLoss = 22,
                Probability = 30
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Alarm Trigger",
                Description = "Your hacking attempt triggers an alarm, alerting security personnel to your presence.",
                SecurityWithGearDescription = "Your intrusion detection software helps you evade capture, but not without raising suspicions.",
                SecurityWithoutGearDescription = "Security personnel swarm your location, forcing you to flee before you're caught.",
                SecurityLoss = 16,
                Probability = 40
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Data Deletion",
                Description = "Your hacking attempt accidentally triggers a data deletion protocol, erasing valuable information.",
                SecurityWithGearDescription = "Your cybersecurity measures prevent total data loss, though some information is still deleted.",
                SecurityWithoutGearDescription = "You inadvertently delete critical data, setting back your hacking progress significantly.",
                SecurityLoss = 4,
                Probability = 50
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Network Isolation",
                Description = "Your hacking attempt triggers a network isolation protocol, cutting off access to external connections.",
                SecurityWithGearDescription = "Your hacking tools help you bypass the network isolation, though not without difficulty.",
                SecurityWithoutGearDescription = "You find yourself completely isolated from the network, unable to proceed with your hacking.",
                SecurityLoss = 8,
                Probability = 40
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Virus Injection",
                Description = "Your hacking attempt inadvertently injects a virus into the system, causing widespread damage.",
                SecurityWithGearDescription = "Your antivirus software helps contain the virus, though not before it spreads to some extent.",
                SecurityWithoutGearDescription = "The virus spreads uncontrollably, causing irreversible damage to the system and drawing attention to your actions.",
                SecurityLoss = 6,
                Probability = 30
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Trace Back",
                Description = "Your hacking attempt is traced back to your location, putting you at risk of legal consequences.",
                SecurityWithGearDescription = "Your anonymizing tools help obfuscate your location, though not without leaving traces.",
                SecurityWithoutGearDescription = "Law enforcement authorities track you down and apprehend you for your hacking activities.",
                SecurityLoss = 45,
                Probability = 20
            });

            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "System Shutdown",
                Description = "Your hacking attempt triggers a system shutdown, cutting off all access and thwarting your efforts.",
                SecurityWithGearDescription = "Your hacking tools help you reboot the system, though not without encountering additional security measures.",
                SecurityWithoutGearDescription = "The system remains shut down indefinitely, leaving you unable to proceed with your hacking.",
                SecurityLoss = 5,
                Probability = 30
            });
    
        }

        private void GenerateExploitEfficiencyItems()
        {
            Items.Add(new Item { Name = "Old Dusty PC", ExploitEfficiency = 20, Price = 100 });
            Items.Add(new Item { Name = "Budget Laptop", ExploitEfficiency = 50, Price = 500 });
            Items.Add(new Item { Name = "Mid-Range Desktop", ExploitEfficiency = 100, Price = 1000 });
            Items.Add(new Item { Name = "Gaming Laptop", ExploitEfficiency = 200, Price = 2000 });
            Items.Add(new Item { Name = "High-End Workstation", ExploitEfficiency = 300, Price = 5000 });
            Items.Add(new Item { Name = "Server Rack", ExploitEfficiency = 400, Price = 10000 });
            Items.Add(new Item { Name = "Datacenter Cluster", ExploitEfficiency = 600, Price = 20000 });
            Items.Add(new Item { Name = "Supercomputer Node", ExploitEfficiency = 800, Price = 50000 });
            Items.Add(new Item { Name = "Quantum Computing Array", ExploitEfficiency = 1000, Price = 100000 });
            Items.Add(new Item { Name = "AI Neural Network", ExploitEfficiency = 1500, Price = 500000 });

        }

        private void GenerateSecurityItems()
        {
            Items.Add(new Item { Name = "Basic Antivirus Software", Security = 50, Price = 50 });
            Items.Add(new Item { Name = "Firewall Protection", Security = 200, Price = 200 });
            Items.Add(new Item { Name = "Encryption Toolset", Security = 300, Price = 300 });
            Items.Add(new Item { Name = "Intrusion Detection System", Security = 500, Price = 500 });
            Items.Add(new Item { Name = "VPN Service", Security = 700, Price = 700 });
            Items.Add(new Item { Name = "Two-Factor Authentication", Security = 1000, Price = 1000 });
            Items.Add(new Item { Name = "Biometric Lock", Security = 1500, Price = 1500 });
            Items.Add(new Item { Name = "Security Camera System", Security = 2000, Price = 2000 });
            Items.Add(new Item { Name = "Fingerprint Scanner", Security = 2500, Price = 2500 });
            Items.Add(new Item { Name = "Facial Recognition System", Security = 3000, Price = 3000 });

        }

        private void GenerateFoodItems()
        {
            Items.Add(new Item { Name = "Water Bottle", ActionCooldownSeconds = 40, Energy = 3, Price = 5 });
            Items.Add(new Item { Name = "Granola Bar", ActionCooldownSeconds = 35, Energy = 4, Price = 7 });
            Items.Add(new Item { Name = "Banana", ActionCooldownSeconds = 30, Energy = 5, Price = 9 });
            Items.Add(new Item { Name = "Energy Drink", ActionCooldownSeconds = 25, Energy = 8, Price = 12 });
            Items.Add(new Item { Name = "Protein Shake", ActionCooldownSeconds = 20, Energy = 10, Price = 15 });
            Items.Add(new Item { Name = "Coffee", ActionCooldownSeconds = 20, Energy = 12, Price = 18 });
            Items.Add(new Item { Name = "Power Bar", ActionCooldownSeconds = 15, Energy = 15, Price = 20 });
            Items.Add(new Item { Name = "Energy Gel", ActionCooldownSeconds = 10, Energy = 20, Price = 25 });
            Items.Add(new Item { Name = "Vitamin Supplements", ActionCooldownSeconds = 5, Energy = 25, Price = 30 });
            Items.Add(new Item { Name = "Superfood Smoothie", ActionCooldownSeconds = 3, Energy = 30, Price = 35 });

#if DEBUG
            Items.Add(new Item { Name = "Developer Food", ActionCooldownSeconds = 0, Energy = 1000, Price = 0 });
#endif
        }

        private void GenerateDecorativeItems()
        {
            Items.Add(new Item { Name = "LED Matrix Clock", Description = "A stylish clock that displays time in binary.", Price = 200 });
            Items.Add(new Item { Name = "RGB Mechanical Keyboard", Description = "Customizable keyboard with flashy RGB lighting.", Price = 300 });
            Items.Add(new Item { Name = "Hackerman Poster", Description = "Vintage poster featuring a hacker in a hoodie, typing furiously.", Price = 150 });
            Items.Add(new Item { Name = "Cyberpunk Action Figure", Description = "Collectible action figure of a cyberpunk hacker with glowing cybernetic implants.", Price = 250 });
            Items.Add(new Item { Name = "WiFi Signal Strength Meter", Description = "A gadget that measures and displays WiFi signal strength in real-time.", Price = 150 });
            Items.Add(new Item { Name = "USB Hub Hub", Description = "A USB hub shaped like a hubcap, because why not?", Price = 100 });
            Items.Add(new Item { Name = "Code Syntax Pillow", Description = "A throw pillow featuring printed code syntax for a popular programming language.", Price = 50 });
            Items.Add(new Item { Name = "Holographic Keyboard Projector", Description = "Projector that displays a holographic keyboard for typing.", Price = 400 });
            Items.Add(new Item { Name = "Hacker Hoodie", Description = "Classic black hoodie with hacker-themed embroidery.", Price = 200 });
            Items.Add(new Item { Name = "Raspberry Pi Cluster Sculpture", Description = "Sculpture made from Raspberry Pi boards arranged in a cluster.", Price = 500 });

        }

    }
}
