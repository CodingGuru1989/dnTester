# dnTester

If an experienced cracker has heard of your software, and develops some unpacker which can make your code viewable in an decompiler, this is something that you have to be prepared for, since .NET code is compiled into the Intermediate Language which is readable by humans.

However, if it comes into Attack, say, code injection, things become interesting. Each protector, even among their own versions, deploys different mechanisms to protect the .NET code, some are useful but some are eye-candy.

This tester will enumerate all the methods in the types, and will look for vulnerable string, thus gives result based on this finding. The tester is open-sourced so you will know how this test is undertaken, and even create your own test if you wish.

The obfuscation process is different from each other. It is not necessarily because that your obfuscator is weak, maybe you had the minimum setting, or due to the version difference. And it often depends on how your code is written.

The tester is useful in some other scenario. Say, one hacker claims to crack your CrackMe, by having tested the unpacked files, you can know that how it has been hacked.

----------

Q : Some target can be unpacked by [de4dot](https://github.com/0xd4d/de4dot), but your tester reports it safe?

A : de4dot is an deobfuscator which will make you code viewable, however, it doesn't say how difficult your software is vulnerable to attacks, say, code injection.

Q: If my software can be unpacked, does it mean unsafe?

A : It depends on the protection on your software. Although the .NET code becomes viewable, sometimes it is not editable on key methods, so to be analyzed by each case.

Q: Why your tester reports different results on the same obfuscator?

A: Because this obfuscator applies different technologies on the different versions. The tester analyzes each version.

----------

*Disclaimer: The tester is automated. And the tester is not optimized for any obfuscator.*